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
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using MilesL.BotherMeNot.Api.Configuration;

namespace MilesL.BotherMeNot.Api.Controllers
{
    [Route("api/[controller]")]
    public class VoiceController : Controller
    {
        private IMapper mapper;

        private IContactAttemptService contactAttemptService;

        private readonly AppOptions options;

        public VoiceController(IContactAttemptService contactAttemptService, IMapper mapper, IOptions<AppOptions> optionsAccessor)
        {
            this.contactAttemptService = contactAttemptService;
            this.mapper = mapper;
            this.options = optionsAccessor.Value;
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
                    responce.Dial(options.RedirectNumber);
                    break;
                case ContactAction.RickRoll:
                    responce.Play(options.RickRollFile);
                    break;
                case ContactAction.HangUp:
                    responce.Hangup();
                    break;
            }

            return Content(responce.ToString(), "application/xml");
        }
    }
}
