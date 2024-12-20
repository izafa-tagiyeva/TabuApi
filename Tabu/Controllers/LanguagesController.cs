using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);    
            return Ok("Language created succesfully");
        }


        [HttpPut]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto _dto)
        {
            await _service.UpdateAsync(code, _dto);

            return Ok("Language updated succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok("Language delete succesfully");
        }
    }
}
