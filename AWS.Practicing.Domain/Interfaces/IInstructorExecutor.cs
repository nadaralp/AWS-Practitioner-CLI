using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces
{
    public interface IInstructorExecutor
    {
        IInstructor Instructor { get; }

        Task ExecuteInstruction(string instruction);
    }
}