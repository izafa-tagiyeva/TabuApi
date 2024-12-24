namespace Tabu.Exceptions.BannerWord
{
    public class BannedWordNotFoundException : Exception , IBaseException
    {

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public BannedWordNotFoundException()
        {
            ErrorMessage = "BannerWord not found!";
        }
        public BannedWordNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
