using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Exceptions
{
    public class InvalidExecutorException<T> : Exception where T : class
    {
        public InvalidExecutorException() : base($"executor that was provided is not of type: {nameof(T)}")
        {
        }
    }
}