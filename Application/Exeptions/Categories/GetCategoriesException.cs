namespace Application.Exeptions
{
    public class GetCategoriesException : Exception
    {
        public GetCategoriesException() : base() { }
        public GetCategoriesException(string message) : base(message) { }
        public GetCategoriesException(string message, Exception inner) : base(message, inner) { }
    }
}
