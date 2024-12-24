using Tabu.DTOs.BannerWords;

namespace Tabu.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task CreateAsync(BannedWordCreateDto dto);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task UpdateAsync(BannedWordUpdateDto dto, int id);
        Task DeleteAsync(int id);

    }
}
