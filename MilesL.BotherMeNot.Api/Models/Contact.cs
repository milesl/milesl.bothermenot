using MilesL.BotherMeNot.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Models
{
    public class Contact : IContact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public ContactAction Action { get; set; }
    }
}
