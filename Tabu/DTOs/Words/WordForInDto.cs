namespace Tabu.DTOs.Words
{
    public class WordForInDto
    {
        public int Id { get; set; } 
        public string Word { get; set; }
        public IEnumerable<string> BannedWrods { get; set; }
    }
}
