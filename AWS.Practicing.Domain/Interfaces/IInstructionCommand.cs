using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces
{
    public interface IInstructionCommand
    {
        Task Execute(); // depends if I can invoke like this with enough knowledge
    }
}