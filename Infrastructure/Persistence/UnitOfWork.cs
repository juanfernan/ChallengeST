using Application.Common.Interfaces;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApplicationDbContext Context { get; }

        public UnitOfWork(IApplicationDbContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
