using Tabu.DTOs.Words;

namespace Tabu.Services.Abstracts
{
    public interface IWordService
    {
        Task<int> CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordForGameDto>> GetAllAsync();
        Task UpdateAsync(WordForGameDto dto, int id);
        Task DeleteAsync(int id);

    }
}
