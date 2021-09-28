using BaseBackEnd.Security.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Security.Infrastructure.Data.EFCore.Context;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Infrastructure.Data.EFCore.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ProjectBaseSecurityContext _dbContext;

        public UnityOfWork(ProjectBaseSecurityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
