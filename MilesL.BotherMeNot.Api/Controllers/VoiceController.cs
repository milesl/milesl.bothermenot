using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MilesL.BotherMeNot.Api.ViewModels;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Services.Interfaces;
using MilesL.BotherMeNot.Api.Models;
using MilesL.BotherMeNot.Api.Configuration;

namespace MilesL.BotherMeNot.Api.Controllers
{
    [Route("api/[controller]")]
    public class VoiceController : Controller
    {
        private IMapper mapper;

        private IContactAttemptService contactAttemptService;

        public VoiceController(IContactAttemptService contactAttemptService, IMapper mapper)
        {
            this.contactAttemptService = contactAttemptService;
            this.mapper = mapper;
        }

        // Post api/voice
        [HttpPost]
        public async Task<IActionResult> Post(VoiceRequest request)
        {
            var contactAttempt = this.mapper.Map<IContactAttempt>(request);
            var contact = this.mapper.Map<IContact>(request);
            var responce = await this.contactAttemptService.HandleVoiceRequest(contactAttempt, contact);

            // Force xml for Twilio
            return Content(responce, "application/xml");
        }
    }
}
