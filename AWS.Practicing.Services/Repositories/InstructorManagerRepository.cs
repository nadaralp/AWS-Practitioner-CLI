using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System;
using System.IO;

namespace AWS.Practicing.Services.Repositories
{
    public class InstructorManagerRepository
    {
        public static IInstructor GetInstructor()
        {
            string instructionsPath = PathHelpers.GetInstructionsPath;
            return new Instructor(instructionsPath);
        }

        public static IInstructorExecutor GetInstructorExecutor(IInstructor instructor)
        {
            return new InstructorExecutor(instructor);
        }

        public static IInstructionCommand GetInstructionCommand(InstructionReplyModel instructionReplyModel)
        {
            InstructionCommandRepository instructionCommandRepository = new InstructionCommandRepository();
            return instructionCommandRepository.GetInstructionCommand(instructionReplyModel);
        }
    }
}