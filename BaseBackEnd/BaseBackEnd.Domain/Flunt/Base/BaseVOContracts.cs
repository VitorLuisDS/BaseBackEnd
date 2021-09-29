using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.Domain.Flunt.Base
{
    internal abstract class BaseVOContracts//<TEntity, TValue>
    {
        protected static string _propertyName;
        public BaseVOContracts(string propertyName)
        {
            _propertyName = propertyName;
        }
    }
}
