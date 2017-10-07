using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Services.Interfaces
{
    public interface IContactAttemptService
    {
        Task<ContactAction> HandleVoiceRequest(IContactAttempt contactAttempt, IContact contact);
    }
}
