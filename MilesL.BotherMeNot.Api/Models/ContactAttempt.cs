using MilesL.BotherMeNot.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Models
{
    public class ContactAttempt : IContactAttempt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public int? ContactId { get; set; }

        public Contact Contact { get; set; }

        public ContactAction? Action { get; set; }

        public DateTime? ContactTime { get; set; }
    }
}
