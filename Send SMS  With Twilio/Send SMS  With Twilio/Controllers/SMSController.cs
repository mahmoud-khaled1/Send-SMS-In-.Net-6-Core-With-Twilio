using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Send_SMS__With_Twilio.Helpers;
using Send_SMS__With_Twilio.Services;

namespace Send_SMS__With_Twilio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _SMSService;

        public SMSController(ISMSService SMSService)
        {
                _SMSService= SMSService;
        }

        [HttpPost("send")]
        public IActionResult SendSMS(SendSMSDto dto)
        {
            var result = _SMSService.Send(dto.MobileNumber, dto.Body);

            if(result.ErrorMessage == null)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
            
        }
    }
}
