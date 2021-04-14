using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Infrastructure.Data.Context;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        readonly ProjectBaseContext _dbContext;

        public UnityOfWork(ProjectBaseContext dbContext)
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
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
