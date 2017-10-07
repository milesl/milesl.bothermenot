using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;
using MilesL.BotherMeNot.Api.ViewModels;
using AutoMapper;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Services.Interfaces;
using MilesL.BotherMeNot.Api.Models;

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

            var action = await this.contactAttemptService.HandleVoiceRequest(contactAttempt, contact);

            var responce = new VoiceResponse();

            switch (action)
            {
                case ContactAction.Redirect:
                    responce.Dial("+447834588765");
                    break;
                case ContactAction.RickRoll:
                    responce.Play("").Hangup();
                    break;
                case ContactAction.HangUp:
                    responce.Hangup();
                    break;
            }

            return this.Ok(responce.ToString());
        }
    }
}
