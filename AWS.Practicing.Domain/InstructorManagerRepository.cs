using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain
{
    public class InstructorManagerRepository
    {
        public static IInstructor GetInstructor()
        {
            // string instructionsPath = app domain directory -> always copy;
            // return new Instructor();
            throw new NotImplementedException();
        }

        public static IInstructorExecutor GetInstructorExecutor(IInstructor instructor)
        {
            throw new NotImplementedException();
        }

        public static IInstructionCommand GetInstructionCommand(InstructionReplyModel instructionReplyModel)
        {
            InstructionCommandRepository instructionCommandRepository = new InstructionCommandRepository();
            return instructionCommandRepository.GetInstructionCommand(instructionReplyModel);
        }
    }
}