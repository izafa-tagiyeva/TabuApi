using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {

            await _service.CreateAsync(dto);    
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            foreach (var item in dto)
            {
                await _service.CreateAsync(item);
            }
          
            return Ok();
        }
    }
}
