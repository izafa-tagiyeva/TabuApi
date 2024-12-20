

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Code = x.Code,
                Name = x.Name,
                Icon = x.Icon,
            }).ToListAsync();
        }
        public async Task<LanguageGetDto> GetByCode(string code)
        {
            var language = await _context.Languages.FindAsync(code);
            if (language == null)
            {
                return null;
            }

            return new LanguageGetDto
            {
                Name = language.Name,
                Icon = language.Icon
            };
        }


        [HttpGet]
        public async Task UpdateAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), "Code cannot be null or empty");
            }
            var data = await GetByCode(code);
            if (data == null)
            {
                throw new KeyNotFoundException("Data not found for the given code");
            }

            LanguageUpdateDto _dto = new();
            _dto.Name = data.Name;
            _dto.Icon = data.Icon;


            await _context.SaveChangesAsync();
        }

       
        [HttpPost]
        public async Task UpdateAsync(string code, LanguageUpdateDto _dto)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), "Code cannot be null or empty");
            }
            var data = await GetByCode(code);
            if (data == null)
            {
                throw new KeyNotFoundException("Data not found for the given code");
            }
            data.Name = _dto.Name;
            data.Icon = _dto.Icon;

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

