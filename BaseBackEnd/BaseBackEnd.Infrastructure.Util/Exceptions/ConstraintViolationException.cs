using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackEnd.Infrastructure.Util.Exceptions
{
    public class ConstraintViolationException : Exception
    {
        public ConstraintViolationException(string message) : base(message)
        {

        }
    }
}
