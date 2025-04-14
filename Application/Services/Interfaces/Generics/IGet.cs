namespace Application.Services.Interfaces
{
    public interface IGet<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
