using System;
using System.Threading.Tasks;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using MilesL.BotherMeNot.Api.Services.Interfaces;

namespace MilesL.BotherMeNot.Api.Services
{
    /// <summary>
    /// Service for managing contact attempts
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Services.Interfaces.IContactAttemptService" />
    public class ContactAttemptService : IContactAttemptService
    {
        /// <summary>
        /// The contact repository
        /// </summary>
        private readonly IContactRepository contactRepository;

        /// <summary>
        /// The contact attempt repository
        /// </summary>
        private readonly IContactAttemptRepository contactAttemptRepository;

        /// <summary>
        /// The contact action accessor
        /// </summary>
        private readonly Func<ContactAction, IContactAction> contactActionAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAttemptService"/> class.
        /// </summary>
        /// <param name="contactRepository">The contact repository.</param>
        /// <param name="contactAttemptRepository">The contact attempt repository.</param>
        /// <param name="contactActionAccessor">The contact action accessor.</param>
        public ContactAttemptService(
            IContactRepository contactRepository,
            IContactAttemptRepository contactAttemptRepository,
            Func<ContactAction, IContactAction> contactActionAccessor)
        {
            this.contactRepository = contactRepository;
            this.contactAttemptRepository = contactAttemptRepository;
            this.contactActionAccessor = contactActionAccessor;
        }

        /// <summary>
        /// Handles the voice request.
        /// </summary>
        /// <param name="contactAttempt">The contact attempt.</param>
        /// <param name="contact">The contact.</param>
        /// <returns>A Twiml response as a string.</returns>
        public async Task<string> HandleVoiceRequest(IContactAttempt contactAttempt, IContact contact)
        {
            // Get or create contact record
            contact = await this.GetOrCreateContact(contact);

            contactAttempt.Action = contact.Action;
            contactAttempt.ContactId = contact.Id;

            await this.contactAttemptRepository.Create(contactAttempt);

            var contactAction = this.contactActionAccessor(contact.Action);

            return contactAction.GetResponse();
        }

        /// <summary>
        /// Gets the or create contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>A instance of <see cref="IContact"/></returns>
        public async Task<IContact> GetOrCreateContact(IContact contact)
        {
            // Has their been contact before
            var contactRecord = await this.contactRepository.GetContactByNumber(contact.Number);
            if (contactRecord == null)
            {
                // Create contact
                await this.contactRepository.Create(contact);
                contactRecord = await this.contactRepository.GetContactByNumber(contact.Number);
            }

            return contactRecord;
        }
    }
}
