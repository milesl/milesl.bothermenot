using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesL.BotherMeNot.Api.Models.Interfaces;
using MilesL.BotherMeNot.Api.Services.Interfaces;
using MilesL.BotherMeNot.Api.ViewModels;

namespace MilesL.BotherMeNot.Api.Controllers.V1
{
    /// <summary>
    /// Controller for handling voice requests from Twilio
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VoiceController : Controller
    {
        /// <summary>
        /// The mapper for mapping between objects
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The contact attempt service
        /// </summary>
        private IContactAttemptService contactAttemptService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceController"/> class.
        /// </summary>
        /// <param name="contactAttemptService">The contact attempt service.</param>
        /// <param name="mapper">The mapper.</param>
        public VoiceController(IContactAttemptService contactAttemptService, IMapper mapper)
        {
            this.contactAttemptService = contactAttemptService;
            this.mapper = mapper;
        }

        /// <summary>
        /// End point for handling post requests
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A Twiml response to the request</returns>
        [HttpPost]
        public async Task<IActionResult> Post(VoiceRequest request)
        {
            var contactAttempt = this.mapper.Map<IContactAttempt>(request);
            var contact = this.mapper.Map<IContact>(request);
            var responce = await this.contactAttemptService.HandleVoiceRequest(contactAttempt, contact);

            // Force xml for Twilio
            return this.Content(responce, "application/xml");
        }
    }
}
