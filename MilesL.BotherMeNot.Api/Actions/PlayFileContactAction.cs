using Microsoft.Extensions.Options;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Configuration;
using Twilio.TwiML;

namespace MilesL.BotherMeNot.Api.Actions
{
    /// <summary>
    /// Contact action for playing a file
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Actions.Interfaces.IContactAction" />
    public class PlayFileContactAction : IContactAction
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly AppOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayFileContactAction"/> class.
        /// </summary>
        /// <param name="optionsAccessor">The options accessor.</param>
        public PlayFileContactAction(IOptions<AppOptions> optionsAccessor)
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
            responce.Play(this.options.PlayFileUrl);
            return responce.ToString();
        }
    }
}
