using MilesL.BotherMeNot.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using MilesL.BotherMeNot.Api.Actions.Interfaces;

namespace MilesL.BotherMeNot.Api.Services
{
    public class ContactAttemptService : IContactAttemptService
    {
        private readonly IContactRepository contactRepository;

        private readonly IContactAttemptRepository contactAttemptRepository;

        private readonly Func<ContactAction, IContactAction> contactActionAccessor;

        public ContactAttemptService(IContactRepository contactRepository,
            IContactAttemptRepository contactAttemptRepository,
            Func<ContactAction, IContactAction> contactActionAccessor)
        {
            this.contactRepository = contactRepository;
            this.contactAttemptRepository = contactAttemptRepository;
            this.contactActionAccessor = contactActionAccessor;
        }

        public async Task<string> HandleVoiceRequest(IContactAttempt contactAttempt, IContact contact)
        {
            // Has their been contact before
            var contactRecord = await this.contactRepository.GetContactByNumber(contact.Number);
            if (contactRecord == null)
            {
                // Create contact
                await this.contactRepository.Create(contact);
                contactRecord = await this.contactRepository.GetContactByNumber(contact.Number);
            }

            contactAttempt.Action = contactRecord.Action;
            contactAttempt.ContactId = contactRecord.Id;

            await this.contactAttemptRepository.Create(contactAttempt);

            var contactAction = this.contactActionAccessor(contactRecord.Action);

            return contactAction.GetResponse();
        }
    }
}
