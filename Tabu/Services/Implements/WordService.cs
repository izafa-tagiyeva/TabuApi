using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Exceptions.Language;
using Tabu.Exceptions.Word;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class WordService(TabuDbContext _context, IMapper _mapper) : IWordService
    {

        public async Task<IEnumerable<WordForGameDto>> GetAllAsync()
        {
            var datas = await _context.Word.Include(x=>x.BannedWords).ToListAsync();
            

             var words = _mapper.Map<IEnumerable<WordForGameDto>>(datas);

             

            return words;
                
        }



        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            //Word word = new Word
            //{
            //    LanguageCode = dto.LanguageCode,
            //    Text = dto.Text
            //};
            var word = _mapper.Map<Word>(dto);
            word.BannedWords=dto.BannerWords.Select(x => new BannedWord
            {
                Text=x
            }).ToList();
            await _context.Word.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;

        }


        public async Task DeleteAsync(int id)
        {
           var data = await _context.Word.FindAsync(id);

            if (data is null)
            throw new WordNotFoundException();
             _context.Word.Remove(data);
            await _context.SaveChangesAsync();
        }

    

        public async Task UpdateAsync(WordForGameDto dto, int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id cannot be null or empty");
            }
            var data = await _context.Word.FindAsync(id);
            if (data == null)
            {
                throw new LanguageNotFoundException();
            }
            _mapper.Map(dto, data);


            await _context.SaveChangesAsync();
        }
    }
}
