using Microsoft.Extensions.Options;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Configuration;
using Twilio.TwiML;

namespace MilesL.BotherMeNot.Api.Actions
{
    /// <summary>
    /// Contact action for redirecting the call
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Actions.Interfaces.IContactAction" />
    public class RedirectContactAction : IContactAction
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly AppOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectContactAction"/> class.
        /// </summary>
        /// <param name="optionsAccessor">The options accessor.</param>
        public RedirectContactAction(IOptions<AppOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }

        /// <summary>
        /// Gets the response for the action.
        /// </summary>
        /// <returns>A Twiml response as a string</returns>
        public string GetResponse()
        {
            var responce = new VoiceResponse();
            responce.Dial(this.options.RedirectNumber);
            return responce.ToString();
        }
    }
}
