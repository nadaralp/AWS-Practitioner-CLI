using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System;
using System.IO;

namespace AWS.Practicing.Services.Factories
{
    public class InstructorManagerFactory
    {
        public static IInstructor GetInstructor()
        {
            return new Instructor();
        }

        public static IInstructorExecutor GetInstructorExecutor(IInstructor instructor)
        {
            return new InstructorExecutor(instructor);
        }

        public static IInstructionCommand GetInstructionCommand(InstructionReplyModel instructionReplyModel)
        {
            InstructionCommandFactory instructionCommandRepository = new InstructionCommandFactory();
            return instructionCommandRepository.GetInstructionCommand(instructionReplyModel);
        }
    }
}