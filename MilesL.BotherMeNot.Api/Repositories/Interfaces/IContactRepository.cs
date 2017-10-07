using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Repositories.Interfaces
{
    public interface IContactRepository : IRepository<Contact, IContact>
    {
        Task<IContact> GetContactByNumber(string number);
    }
}
