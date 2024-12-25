

using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Exceptions.Language;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();

            await _context.Languages.AddAsync( 
                _mapper.Map<Language>(dto));

            //new Entities.Language
            //{
            //    Code = dto.Code,
            //    Name = dto.Name,
            //    Icon = dto.Icon,
            //}); 
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            
            var datas = await _context.Languages.ToListAsync();
            
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);

        }
        //[HttpGet]
        //public async Task<LanguageGetDto> GetByCode(string code)
        //{
        //    var language = await _context.Languages.FindAsync(code);
        //    if (language == null)
        //    {
        //        return null;
        //    }

        //    return new LanguageGetDto
        //    {
        //        Name = language.Name,
        //        Icon = language.Icon
        //    };
        //}


        //[HttpPut]
        public async Task UpdateAsync(string code, LanguageUpdateDto _dto)
        {

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), "Code cannot be null or empty");
            }
            var data = await _context.Languages.FindAsync(code); ;
            if (data == null)
            {
                throw new LanguageNotFoundException();
            }

            data.Name = _dto.Name;
            data.Icon = _dto.Icon;
  
            //_mapper.Map(_dto, data);

            await _context.SaveChangesAsync();


        }

       
       

        public async Task DeleteAsync(string code)
        {

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), "Code cannot be null or empty");
            }
            var data = await _context.Languages.FindAsync(code);
            if (data == null)
            {
                throw new KeyNotFoundException("Data not found for the given code");
            }
            _context.Languages.Remove(data);
            await _context.SaveChangesAsync();
         }
      




    }
}

