using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;

namespace MilesL.BotherMeNot.Api.Repositories.Interfaces
{
    /// <summary>
    /// Interface representing a contact attempt repository
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Interfaces.IRepository{MilesL.BotherMeNot.Api.Models.ContactAttempt, MilesL.BotherMeNot.Api.Models.Interfaces.IContactAttempt}" />
    public interface IContactAttemptRepository : IRepository<ContactAttempt, IContactAttempt>
    {
    }
}
