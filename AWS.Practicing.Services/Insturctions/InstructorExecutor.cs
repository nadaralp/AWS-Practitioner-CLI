﻿using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services
{
    public class InstructorExecutor : IInstructorExecutor
    {
        public IInstructor Instructor { get; private set; }

        public InstructorExecutor(IInstructor instructor)
        {
            Instructor = instructor;
        }

        public async Task ExecuteInstruction()
        {
            IInstructionCommand instructionCommand = InstructorManagerFactory.GetInstructionCommand(Instructor.InstructionReplyModel);
            await instructionCommand.Execute();
        }
    }
}