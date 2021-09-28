using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Interfaces.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
