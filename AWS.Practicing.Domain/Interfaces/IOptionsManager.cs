using AWS.Practicing.Domain.Exceptions;
using AWS.Practicing.Domain.Models;
using System.Collections.Generic;

namespace AWS.Practicing.Domain.Interfaces
{
    public interface IOptionsManager
    {
        /// <summary>
        /// Get the instruction
        /// </summary>
        /// <example>Choose service to operate on</example>
        string InstructionDescription { get; }

        /// <summary>
        /// Get options to ask
        /// </summary>
        ICollection<OptionsSchema> Options { get; }

        /// <summary>
        /// Ensures a valid response is persisting.
        /// </summary>
        /// <exception cref="InvalidReplyException"
        void EnsureValidResponse(InstructionReplyModel replyModel);

        /// <summary>
        /// Determines if the history path has an executor to be executed.
        /// </summary>
        bool HasOptionExecutorForHistoryPath(InstructionReplyModel replyModel);
    }
}