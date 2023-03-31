using Microsoft.Extensions.Options;
using Send_SMS__With_Twilio.Helpers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Send_SMS__With_Twilio.Services
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _twilio;
        public SMSService(IOptions<TwilioSettings> twilioSettings)
        {
            _twilio = twilioSettings.Value;
        }
        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            var result = MessageResource.Create(
                body:body,
                from:new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                to:mobileNumber
                );
            return result;
        }
    }
}
