using Tabu.DTOs.BannerWords;

namespace Tabu.Services.Abstracts
{
    public interface IBannedWordService
    {
        
        Task UpdateAsync(BannedWordUpdateDto dto, int id);
      
    }
}
