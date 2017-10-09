using System.Threading.Tasks;
using MilesL.BotherMeNot.Api.Models.Interfaces;

namespace MilesL.BotherMeNot.Api.Services.Interfaces
{
    /// <summary>
    /// Service for managing contact attempts
    /// </summary>
    public interface IContactAttemptService
    {
        /// <summary>
        /// Handles the voice request.
        /// </summary>
        /// <param name="contactAttempt">The contact attempt.</param>
        /// <param name="contact">The contact.</param>
        /// <returns>A Twiml response as a string.</returns>
        Task<string> HandleVoiceRequest(IContactAttempt contactAttempt, IContact contact);

        /// <summary>
        /// Gets the or create contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>A instance of <see cref="IContact"/></returns>
        Task<IContact> GetOrCreateContact(IContact contact);
    }
}
