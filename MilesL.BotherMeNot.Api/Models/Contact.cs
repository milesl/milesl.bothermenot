using System.ComponentModel.DataAnnotations.Schema;
using MilesL.BotherMeNot.Api.Models.Interfaces;

namespace MilesL.BotherMeNot.Api.Models
{
    /// <summary>
    /// Contact domain model
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Models.Interfaces.IContact" />
    public class Contact : IContact
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public ContactAction Action { get; set; }
    }
}
