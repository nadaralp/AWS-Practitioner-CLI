using AWS.Practicing.Common;
using AWS.Practicing.Domain.Exceptions;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AWS.Practicing.Services
{
    public abstract class BaseOptionsManager : IOptionsManager
    {
        protected InstructionsOptionsGraph InstructionsOptionsGraph { get; }
        protected InstructionReplyModel InstructionReplyModel { get; }

        protected InstructionOption GetCurrentInstruction
         =>
            InstructionsOptionsGraph[InstructionReplyModel];

        public abstract ICollection<OptionsSchema> Options { get; }

        public BaseOptionsManager(InstructionReplyModel instructionReplyModel)
        {
            InstructionsOptionsGraph = OptionsHelper.GetInstructionOptionsGraphFromJsonFile();
            InstructionReplyModel = instructionReplyModel;
        }

        public virtual void EnsureValidResponse(InstructionReplyModel replyModel)
        {
            IEnumerable<string> optionalKeys = Options.Select(option => option.Key.ToLower());
            if (optionalKeys.Contains(replyModel.Response.ToLower()))
            {
                throw new InvalidReplyException(replyModel);
            }
        }
    }
}