using System.Threading.Tasks;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;

namespace MilesL.BotherMeNot.Api.Repositories.Interfaces
{
    /// <summary>
    /// Interface representing a contact repository
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Interfaces.IRepository{MilesL.BotherMeNot.Api.Models.Contact, MilesL.BotherMeNot.Api.Models.Interfaces.IContact}" />
    public interface IContactRepository : IRepository<Contact, IContact>
    {
        /// <summary>
        /// Gets the contact by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        Task<IContact> GetContactByNumber(string number);
    }
}
