using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Extensions;
using Tabu.Services.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tabu.Services.Implements
{
    public class GameService(TabuDbContext _context, IMapper _mapper, IMemoryCache _cache) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
         public async Task<WordForInDto> Success(Guid Id)
        {
            var status = _getCurrentGame(Id);
            var currentWord = status.Words.Pop();
            status.Success++;
            _cache.Set(Id, status, TimeSpan.FromSeconds(300));
            return currentWord;
        }

        public async Task<WordForInDto> Fail(Guid Id)
        {
            var status = _getCurrentGame(Id);
            var currentWord = status.Words.Pop();
            status.Fail++;
            _cache.Set(Id, status, TimeSpan.FromSeconds(300));
            return currentWord;

        }

        public async Task<int> End(Guid Id)
        {
            var status = _getCurrentGame(Id);
            await Task.Delay( 10 * 1000);
           
            int score = (3 * status.Success) - status.Fail;

            return score;
        }

        public async Task<WordForInDto> Skip(Guid Id)
        {
            var status = _getCurrentGame(Id);
            if (status.Skip <= status.MaxSkipCount) { 
                var currentWord = status.Words.Pop();
                status.Skip++;
                _cache.Set(Id, status, TimeSpan.FromSeconds(300) );
                return currentWord;
            }
            return null;  


        }

        public async Task<WordForInDto> Start(Guid Id)
        {
            var game = await _context.Games.FindAsync(Id);
            if (game == null || game.Score != null)
            {
                throw new NotImplementedException();
            }

            IQueryable<Word> query = _context.Word.Where(x => x.LanguageCode == game.LanguageCode);
            var words =  await query.Select(x => new WordForInDto
            {
                Id = x.Id,
                Word = x.Text,
                BannedWrods= x.BannedWords.Select(y => y.Text)
            }).Random(await query.CountAsync())
               .Take(20)
               .ToListAsync();

            var wordsStack = new Stack<WordForInDto>(words);
            WordForInDto currentWord = wordsStack.Pop();
            
            GameStatusDto status = new GameStatusDto() 
            { 
                Fail = 0,
                Skip= 0,
                Success= 0,
                Words = wordsStack,
                UsedWordId = words.Select(x => x.Id),
                MaxSkipCount = (byte)game.SkipCount,

            };

            _cache.Set(Id, status , TimeSpan.FromSeconds(300)); //game.Time+20
            return currentWord;
        }

     

        GameStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GameStatusDto>(id);   
            if (result == null)    throw new NotImplementedException(); 
            return result;
        }


    }
}
