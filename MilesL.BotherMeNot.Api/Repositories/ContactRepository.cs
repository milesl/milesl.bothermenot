using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MilesL.BotherMeNot.Api.Repositories
{
    public class ContactRepository : Repository<Contact, IContact>, IContactRepository
    {
        public ContactRepository(BotherMeNotDbContext dbConext) : base(dbConext) { }

        public async Task<IContact> GetContactByNumber(string number)
        {
            var result = await this.Get(e => e.Number == number);
            return result.SingleOrDefault();
        }
    }
}
