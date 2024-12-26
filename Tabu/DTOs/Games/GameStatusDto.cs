using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Success { get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public int Time { get; set; }
        public Stack<WordForInDto> Words { get; set; }
        public IEnumerable<int> UsedWordId { get; set; }
        public int MaxSkipCount { get; set; }
    }
}
