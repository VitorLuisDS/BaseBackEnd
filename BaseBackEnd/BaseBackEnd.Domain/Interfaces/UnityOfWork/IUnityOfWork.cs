using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Domain.Interfaces.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
