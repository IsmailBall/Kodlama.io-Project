using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Commands.DeleteLanguage;
using Kodlama.io.Devs.Application.Features.Commands.UpdateLanguage;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Features.Quries.GetListLanguageQuery;
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteLanguageCommand deleteLanguageCommand)
        {
            LanguageListDto result = await Mediator.Send(deleteLanguageCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            LanguageUpdateDto result = await Mediator.Send(updateLanguageCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var getListQuerry = new GetListLanguageQuerry { PageRequest = pageRequest };

            var result = await Mediator.Send(getListQuerry);

            return Ok(result);
        }
    }
}
