using AutoMapper;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Mappings
{
    public class ContactMappings : Profile
    {
        public ContactMappings()
        {
            CreateMap<VoiceRequest, IContact>().As<Contact>();
            CreateMap<VoiceRequest, IContactAttempt>().As<ContactAttempt>();
            CreateMap<VoiceRequest, Contact>().ConvertUsing((v, c) => new Contact() { Name = v.CallerName, Number = v.From });
            CreateMap<VoiceRequest, ContactAttempt>().ConvertUsing((v, c) => new ContactAttempt() { Contact = null, ContactTime = DateTime.Now });
        }
    }
}
