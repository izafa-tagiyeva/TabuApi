namespace Tabu.Exceptions.BannerWord
{
    public class BannedWordExistException : Exception , IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;
        public string ErrorMessage { get; }
        public BannedWordExistException()
        {
            ErrorMessage = "BannedWord already exist in  database";
        }

        public BannedWordExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }

    }
}
