using AutoMapper;
using Tabu.DAL;
using Tabu.DTOs.BannerWords;
using Tabu.Exceptions.Language;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class BannedWordService(TabuDbContext _context, IMapper _mapper) : IBannedWordService
    {
        public async Task UpdateAsync(BannedWordUpdateDto dto, int id)
        {
           
            var data = await _context.BannedWord.FindAsync(id);
          
            _mapper.Map(dto, data);


            await _context.SaveChangesAsync();
        }
    }

    //public Task UpdateAsync(BannedWordUpdateDto dto, int id)
    //{
    //    throw new NotImplementedException();
    //}
}


