using System;
using System.ComponentModel.DataAnnotations.Schema;
using MilesL.BotherMeNot.Api.Models.Interfaces;

namespace MilesL.BotherMeNot.Api.Models
{
    /// <summary>
    /// Contact attempt domain model representing a attempted contact
    /// </summary>
    /// <seealso cref="MilesL.BotherMeNot.Api.Models.Interfaces.IContactAttempt" />
    public class ContactAttempt : IContactAttempt
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
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        public int? ContactId { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public ContactAction? Action { get; set; }

        /// <summary>
        /// Gets or sets the contact time.
        /// </summary>
        /// <value>
        /// The contact time.
        /// </value>
        public DateTime? ContactTime { get; set; }
    }
}
