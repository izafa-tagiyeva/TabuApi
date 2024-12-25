using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Exceptions;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(await _service.GetAllAsync());
        }

        ////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);

                return Ok("created succesfully");
            }
            catch (Exception ex) {
                if (ex is IBaseException bEx)
                {

                    return StatusCode(bEx.StatusCode, new
                    {
                        
                        Message = bEx.ErrorMessage          
                    } );
                }
                else
                {
                    return BadRequest(
                        new
                        {

                            Message = ex.Message,
                        });
                }
            }
           
        }

        ////////////////////////////////////////////////////////////

        [HttpPut]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto _dto)
        {
            await _service.UpdateAsync(code, _dto);
          //var data = _mapper.Map<Language>( _dto);

            return Ok();
        }

        ////////////////////////////////////////////////////////////
    
        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok("Language delete succesfully");
        }
    }
}
