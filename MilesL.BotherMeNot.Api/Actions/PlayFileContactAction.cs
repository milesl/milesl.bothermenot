using Microsoft.Extensions.Options;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Configuration;
using Twilio.TwiML;

namespace MilesL.BotherMeNot.Api.Actions
{
    public class PlayFileContactAction : IContactAction
    {
        private readonly AppOptions options;

        public PlayFileContactAction(IOptions<AppOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }

        public string GetResponse()
        {
            var responce = new VoiceResponse();
            responce.Play(options.PlayFileUrl);
            return responce.ToString();
        }
    }
}
