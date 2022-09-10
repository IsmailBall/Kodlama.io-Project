using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            LanguageCreateDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
    }
}
