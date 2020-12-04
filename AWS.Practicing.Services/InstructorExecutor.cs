using AWS.Practicing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services
{
    public class InstructorExecutor : IInstructorExecutor
    {
        public IInstructor Instructor => throw new NotImplementedException();

        public Task ExecuteInstruction(string instruction)
        {
            // Get a command from the replymodel
            // execute the comand.
            throw new NotImplementedException();
        }
    }
}