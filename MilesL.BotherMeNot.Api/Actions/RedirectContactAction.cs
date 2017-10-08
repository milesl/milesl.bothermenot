using Microsoft.Extensions.Options;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Configuration;
using Twilio.TwiML;

namespace MilesL.BotherMeNot.Api.Actions
{
    public class RedirectContactAction : IContactAction
    {
        private readonly AppOptions options;

        public RedirectContactAction(IOptions<AppOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }

        public string GetResponse()
        {
            var responce = new VoiceResponse();
            responce.Dial(options.RedirectNumber);
            return responce.ToString();
        }
    }
}
