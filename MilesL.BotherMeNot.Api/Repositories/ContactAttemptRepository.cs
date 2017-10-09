using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;

namespace MilesL.BotherMeNot.Api.Repositories
{
    /// <summary>
    /// Contact Attempt Repository for accessing contact attempt data
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Repository{MilesL.BotherMeNot.Api.Models.ContactAttempt, MilesL.BotherMeNot.Api.Models.Interfaces.IContactAttempt}" />
    /// <seealso cref="MilesL.BotherMeNot.Api.Repositories.Interfaces.IContactAttemptRepository" />
    public class ContactAttemptRepository : Repository<ContactAttempt, IContactAttempt>, IContactAttemptRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAttemptRepository"/> class.
        /// </summary>
        /// <param name="dbConext">The database conext.</param>
        public ContactAttemptRepository(BotherMeNotDbContext dbConext)
            : base(dbConext)
        {
        }
    }
}
