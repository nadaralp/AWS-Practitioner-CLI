using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces
{
    public interface IInstructor
    {
        /// <summary>
        /// Asks a question based on the instruction current index and expects an answer
        /// </summary>
        string Ask();

        /// <summary>
        /// Validates the response received from asking a question on the current stage
        /// </summary>
        /// <returns></returns>
        bool IsValidResponse(string response);

        void EnsureValidResponse(string response);

        /// <summary>
        /// Determines if finished asking all questions to perform insturctions
        /// </summary>
        bool IsFinishedAsking { get; }
    }
}