using AWS.Practicing.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWS.Practicing.Domain.Models
{
    public class InstructionsOptionsGraph
    {
        public List<InstructionsListPerLevel> InstructionsGraph { get; set; } // Instructions represent a graph of choices on each step.

        public InstructionOption this[InstructionReplyModel instructionReplyModel]
        {
            get
            {
                InstructionsListPerLevel instructionListPerLevel = InstructionsGraph[instructionReplyModel.Step];
                if (instructionReplyModel.Response == InstructionReplyModel.EmptyResponse)
                {
                    return instructionListPerLevel.InstructionOptions[0];
                }

                InstructionOption instructionOption = instructionListPerLevel.InstructionOptions
                    .FirstOrDefault(option => option.Trigger.ToLower() == instructionReplyModel.ExecutionHistoryPath.ToLower());

                return instructionOption ?? throw new InvalidReplyException(instructionReplyModel);
            }
        }
    }

    public class InstructionsListPerLevel
    {
        public List<InstructionOption> InstructionOptions { get; set; }
    }

    public class InstructionOption
    {
        public string Trigger { get; set; }
        public string Instruction { get; set; }
        public List<OptionsSchema> Options { get; set; }

        #region Dynamic Options Props

        public string OptionsDynamicExecutorFullPath { get; set; }

        #endregion Dynamic Options Props
    }
}