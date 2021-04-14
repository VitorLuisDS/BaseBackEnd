using System;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
