using MilesL.BotherMeNot.Api.Actions;
using MilesL.BotherMeNot.Api.Actions.Interfaces;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using MilesL.BotherMeNot.Api.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MilesL.BotherMeNot.Api.Tests.Services
{
    public class ContactAttemptServiceTests
    {
        private Mock<IContactRepository> moqContactRepository = new Mock<IContactRepository>();
        private Mock<IContactAttemptRepository> moqContactAttemptRepository = new Mock<IContactAttemptRepository>();
        private Mock<Func<ContactAction, IContactAction>> moqContactActionAccessor = new Mock<Func<ContactAction, IContactAction>>();

        [Fact]
        public async void GetContactOrCreate_Creates_Contact_If_None_Exists()
        {
            var contact = new Contact() { Action = ContactAction.HangUp, Id = 1, Name = "Test", Number = "+4471234567898" };
            moqContactRepository.Setup(m => m.GetContactByNumber(It.IsAny<string>())).ReturnsAsync((IContact)null);
            var contactAttemptService = new ContactAttemptService(moqContactRepository.Object, moqContactAttemptRepository.Object, moqContactActionAccessor.Object);
            var result = await contactAttemptService.GetContactOrCreate(contact);
            moqContactRepository.Verify(m => m.Create(It.IsAny<IContact>()), Times.Once);
            Assert.True(true);
        }

        [Fact]
        public async void GetContactOrCreate_Does_Not_Create_Contact_If_One_Exists()
        {
            // Declare data
            var contact = new Contact() { Action = ContactAction.HangUp, Id = 1, Name = "Test", Number = "+4471234567898" };

            // Setup mocks
            moqContactRepository.Setup(m => m.GetContactByNumber(It.IsAny<string>())).ReturnsAsync(contact);

            // Run test
            var contactAttemptService = new ContactAttemptService(moqContactRepository.Object, moqContactAttemptRepository.Object, moqContactActionAccessor.Object);
            var result = await contactAttemptService.GetContactOrCreate(contact);

            // Check results
            moqContactRepository.Verify(m => m.Create(It.IsAny<IContact>()), Times.Never);
            Assert.Equal(contact, result);
        }

        [Fact]
        public async void HandleVoiceRequest_Populates_Contact_Attempt_Call_Details()
        {
            // Declare data
            var contact = new Contact() { Action = ContactAction.HangUp, Id = 1, Name = "Test", Number = "+4471234567898" };
            var contactAttempt = new ContactAttempt() { ContactTime = DateTime.Now };

            // Setup mocks
            moqContactRepository.Setup(m => m.GetContactByNumber(It.IsAny<string>())).ReturnsAsync(contact);
            moqContactActionAccessor.Setup(m => m(It.IsAny<ContactAction>())).Returns(new HangUpContactAction());

            // Run test
            var contactAttemptService = new ContactAttemptService(moqContactRepository.Object, moqContactAttemptRepository.Object, moqContactActionAccessor.Object);
            var result = await contactAttemptService.HandleVoiceRequest(contactAttempt, contact);

            // Check results
            Assert.Equal(contactAttempt.Action, contact.Action);
            Assert.Equal(contactAttempt.ContactId, contact.Id);
        }

        [Fact]
        public async void HandleVoiceRequest_Creates_Contact_Attempt()
        {
            // Declare data
            var contact = new Contact() { Action = ContactAction.HangUp, Id = 1, Name = "Test", Number = "+4471234567898" };
            var contactAttempt = new ContactAttempt() { ContactTime = DateTime.Now };

            // Setup mocks
            moqContactRepository.Setup(m => m.GetContactByNumber(It.IsAny<string>())).ReturnsAsync(contact);
            moqContactActionAccessor.Setup(m => m(It.IsAny<ContactAction>())).Returns(new HangUpContactAction());

            // Run test
            var contactAttemptService = new ContactAttemptService(moqContactRepository.Object, moqContactAttemptRepository.Object, moqContactActionAccessor.Object);
            var result = await contactAttemptService.HandleVoiceRequest(contactAttempt, contact);

            // Check results
            moqContactAttemptRepository.Verify(m => m.Create(It.IsAny<IContactAttempt>()), Times.Once);
            Assert.True(true);
        }

        [Fact]
        public async void HandleVoiceRequest_Loads_Action_From_Contact_Record()
        {
            // Declare data
            var contact = new Contact() { Action = ContactAction.HangUp, Id = 1, Name = "Test", Number = "+4471234567898" };
            var contactAttempt = new ContactAttempt() { ContactTime = DateTime.Now };
            HangUpContactAction contactAction = new HangUpContactAction();

            // Setup mocks
            moqContactRepository.Setup(m => m.GetContactByNumber(It.IsAny<string>())).ReturnsAsync(contact);
            moqContactActionAccessor.Setup(m => m(It.IsAny<ContactAction>())).Returns(contactAction);

            // Run test
            var contactAttemptService = new ContactAttemptService(moqContactRepository.Object, moqContactAttemptRepository.Object, moqContactActionAccessor.Object);
            var result = await contactAttemptService.HandleVoiceRequest(contactAttempt, contact);

            // Check results
            Assert.Equal(contactAction.GetResponse(), result);
        }
    }
}
