using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Models.Interfaces
{
    public interface IContact
    {
        int? Id { get; set; }

        string Name { get; set; }

        string Number { get; set; }

        ContactAction Action { get; set; }
    }
}
