using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration;
using QLNH.Common.Req;


namespace QLNH.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SmsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("send")]
        public IActionResult SendSms([FromBody] SmsReq request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.PhoneNumber))
            {
                return BadRequest("Name and phone number are required.");
            }

            // Ensure the phone number is in E.164 format
            var phoneNumber = request.PhoneNumber;
            if (!phoneNumber.StartsWith("+"))
            {
                phoneNumber = "+84" + phoneNumber.Substring(1); // Assuming +84 is the country code for Vietnam
            }

            var accountSid = _configuration["Twilio:AccountSID"];
            var authToken = _configuration["Twilio:AuthToken"];
            var fromPhoneNumber = _configuration["Twilio:PhoneNumber"];

            TwilioClient.Init(accountSid, authToken);

            var message = $"Hello {request.Name}, this is a test message from our system!";
            var messageOptions = new CreateMessageOptions(new PhoneNumber(phoneNumber))
            {
                From = new PhoneNumber(fromPhoneNumber),
                Body = message
            };

            try
            {
                var messageResource = MessageResource.Create(messageOptions);
                return Ok($"SMS sent successfully to {phoneNumber}. Message SID: {messageResource.Sid}");
            }
            catch (Twilio.Exceptions.ApiException ex)
            {
                return BadRequest($"Failed to send SMS: {ex.Message}");
            }
        }
    }
}
