using System;
using AutoMapper;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.ViewModels;

namespace MilesL.BotherMeNot.Api.Mappings
{
    /// <summary>
    /// Automapper profile containing mappings for Contact models
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ContactMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactMappings"/> class.
        /// </summary>
        public ContactMappings()
        {
            this.CreateMap<VoiceRequest, IContact>().As<Contact>();
            this.CreateMap<VoiceRequest, IContactAttempt>().As<ContactAttempt>();
            this.CreateMap<VoiceRequest, Contact>().ConvertUsing((v, c) => new Contact() { Name = v.CallerName, Number = v.From });
            this.CreateMap<VoiceRequest, ContactAttempt>().ConvertUsing((v, c) => new ContactAttempt() { Contact = null, ContactTime = DateTime.Now });
        }
    }
}
