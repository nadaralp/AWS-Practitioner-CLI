using AWS.Practicing.Domain.Exceptions;
using AWS.Practicing.Domain.Models;
using System.Collections.Generic;

namespace AWS.Practicing.Domain.Interfaces
{
    public interface IOptionsManager
    {
        /// <summary>
        /// Get options to ask
        /// </summary>
        ICollection<OptionsSchema> Options { get; }

        /// <summary>
        /// Ensures a valid response is persisting.
        /// </summary>
        /// <exception cref="InvalidReplyException"
        void EnsureValidResponse(InstructionReplyModel replyModel);
    }
}