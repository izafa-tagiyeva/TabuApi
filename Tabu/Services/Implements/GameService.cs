using AutoMapper;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.Entities;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class GameService(TabuDbContext _context, IMapper _mapper) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public Task EndAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task FailAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task SkipAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task SuccessAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
