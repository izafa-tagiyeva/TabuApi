using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.BannerWords;
using Tabu.DTOs.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedWordService _service) : ControllerBase
    {
        [HttpPut]
        public async Task<IActionResult> Update(BannedWordUpdateDto dto, int id)
        {
            await _service.UpdateAsync(dto, id);
            //var data = _mapper.Map<Language>( _dto);

            return Ok();
        }
    }
}
