using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Insturctions
{
    public class InstructorExecutor : IInstructorExecutor
    {
        public IInstructor Instructor { get; private set; }

        public IInstructionCommand InstructionCommand
            => InstructorManagerFactory.GetInstructionCommand(Instructor.InstructionReplyModel);

        public InstructorExecutor(IInstructor instructor)
        {
            Instructor = instructor;
        }
    }
}