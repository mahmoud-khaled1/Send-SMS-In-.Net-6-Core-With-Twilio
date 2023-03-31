using Twilio.Rest.Api.V2010.Account;

namespace Send_SMS__With_Twilio.Services
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);
    }
}
