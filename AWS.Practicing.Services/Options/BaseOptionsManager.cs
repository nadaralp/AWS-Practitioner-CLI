using AWS.Practicing.Common;
using AWS.Practicing.Domain.Exceptions;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using AWS.Practicing.Services.Factories;
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
        protected InstructionReplyModel InstructionReplyModel { get; }

        protected InstructionOption InstructionOption { get; }

        public abstract ICollection<OptionsSchema> Options { get; }

        public BaseOptionsManager(InstructionReplyModel instructionReplyModel)
        {
            InstructionReplyModel = instructionReplyModel;
            var instructionsOptionsGraph = OptionsHelper.GetInstructionOptionsGraphFromJsonFile();
            InstructionOption = instructionsOptionsGraph[instructionReplyModel];
        }

        public virtual void EnsureValidResponse(InstructionReplyModel replyModel)
        {
            IEnumerable<string> optionalKeys = Options.Select(option => option.Key.ToLower());
            if (!optionalKeys.Contains(replyModel.Response.ToLower()))
            {
                throw new InvalidReplyException(replyModel);
            }

            InstructionReplyModel.UpdateStep(); //side effect?
        }

        public bool HasOptionExecutorForHistoryPath(InstructionReplyModel replyModel)
        {
            // that's a very expensive implementation. There should be a singleton for the YAML DTO that we can query against.

            try
            {
                InstructionCommandFactory commandFactory = new InstructionCommandFactory();
                commandFactory.GetInstructionCommand(replyModel);
                return true;
            }
            catch (InstructionNotImplementedException)
            {
                return false;
            }
        }
    }
}