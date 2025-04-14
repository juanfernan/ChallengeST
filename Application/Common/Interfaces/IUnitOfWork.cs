namespace Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IApplicationDbContext Context { get; }
    }
}
