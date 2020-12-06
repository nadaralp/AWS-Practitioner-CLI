using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System.Collections.Generic;

namespace AWS.Practicing.Services
{
    public class BasicOptionsManager : BaseOptionsManager, IOptionsManager
    {
        public BasicOptionsManager(InstructionReplyModel instructionReplyModel) : base(instructionReplyModel)
        {
        }

        public override ICollection<OptionsSchema> Options
        {
            get
            {
                return GetCurrentInstruction.Options;
            }
        }
    }
}