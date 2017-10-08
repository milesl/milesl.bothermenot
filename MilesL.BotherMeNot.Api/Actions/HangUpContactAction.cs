using MilesL.BotherMeNot.Api.Actions.Interfaces;
using Twilio.TwiML;

namespace MilesL.BotherMeNot.Api.Actions
{
    public class HangUpContactAction : IContactAction
    {
        public string GetResponse()
        {
            var responce = new VoiceResponse();
            responce.Hangup();
            return responce.ToString();
        }
    }
}
