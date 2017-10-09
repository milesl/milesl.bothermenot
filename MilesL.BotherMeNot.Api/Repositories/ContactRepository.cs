using System.Linq;
using System.Threading.Tasks;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;

namespace MilesL.BotherMeNot.Api.Repositories
{
    /// <summary>
    /// Contact repositoy for accessing contact data
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Repository{MilesL.BotherMeNot.Api.Models.Contact, MilesL.BotherMeNot.Api.Models.Interfaces.IContact}" />
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Interfaces.IContactRepository" />
    public class ContactRepository : Repository<Contact, IContact>, IContactRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="dbConext">The database conext.</param>
        public ContactRepository(BotherMeNotDbContext dbConext)
            : base(dbConext)
        {
        }

        /// <summary>
        /// Gets the contact by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>A contact</returns>
        public async Task<IContact> GetContactByNumber(string number)
        {
            var result = await this.Get(e => e.Number == number);
            return result.SingleOrDefault();
        }
    }
}
