using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Tabu.DTOs.Games;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameService _service,IMemoryCache _cache) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Start(Guid Id)
        {
            return Ok(await _service.Start(Id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Skip(Guid Id)
        {
            return Ok(await _service.Skip(Id));
        }






        //[HttpGet("[action]")]
        //public async Task<IActionResult> Get(string key)
        //{
        //    return Ok(_cache.Get(key));
        //}


        //[HttpGet("[action]")]
        //public async Task<IActionResult> Set(string key, string value)
        //{
        //    return Ok(_cache.Set<string>(key , value , DateTime.Now.AddSeconds(20)));
        //}




    }
}
