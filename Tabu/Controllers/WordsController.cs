using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.DTOs.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service ) : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _service.GetAllAsync());
        }
        
        ////////////////////////////////////////////////////////////////////////////////////
    

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

        ////////////////////////////////////////////////////////////

        [HttpPut]
        public async Task<IActionResult> Update( WordForGameDto _dto, int id)
        {
            await _service.UpdateAsync(_dto, id);
            //var data = _mapper.Map<Language>( _dto);

            return Ok();
        }

        ////////////////////////////////////////////////////////////

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Language delete succesfully");
        }





    }
}
