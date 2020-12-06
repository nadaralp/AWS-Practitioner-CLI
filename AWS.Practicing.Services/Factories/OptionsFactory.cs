using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Factories
{
    public class OptionsFactory
    {
        public static IOptionsManager GetOptionsManager(InstructionReplyModel instructionReplyModel)
        {
            InstructionsOptionsGraph instructionsOptionsGraph = OptionsHelper.GetInstructionOptionsGraphFromJsonFile();
            InstructionOption instructionOption = instructionsOptionsGraph[instructionReplyModel];

            if (instructionOption.Options is null)
            {
                // probably more data needed in order to create that with reflection
                return new DynamicOptionsManager(instructionReplyModel);
            }

            return new BasicOptionsManager(instructionReplyModel);
        }
    }
}