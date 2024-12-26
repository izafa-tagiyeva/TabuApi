using Tabu.DAL;
using Tabu.Entities;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class GameService(TabuDbContext _context) : IGameService
    {
        public Task CreateAsync(Game Dto)
        {
            throw new NotImplementedException();
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
