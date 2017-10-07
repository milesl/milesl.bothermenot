using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Models.Interfaces
{
    public interface IContactAttempt
    {
        int? Id { get; set; }

        int? ContactId { get; set; }

        Contact Contact { get; set; }

        ContactAction? Action { get; set; }

        DateTime? ContactTime { get; set; }
    }
}
