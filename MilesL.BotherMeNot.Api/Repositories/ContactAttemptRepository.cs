using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MilesL.BotherMeNot.Api.Repositories
{
    public class ContactAttemptRepository : Repository<ContactAttempt, IContactAttempt>, IContactAttemptRepository
    {
        public ContactAttemptRepository(BotherMeNotDbContext dbConext) : base(dbConext) { }
    }
}
