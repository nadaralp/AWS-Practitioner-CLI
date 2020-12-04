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
        /// Ensures a valid response is persisting.
        /// </summary>
        /// <returns></returns>
        void EnsureValidResponse(string response);

        /// <summary>
        /// Determines if finished asking all questions to perform insturctions
        /// </summary>
        bool IsFinishedAsking { get; }

        /// <summary>
        /// Checks if instructor finished asking question and updates IsFinishedAsking to true if needed.
        /// </summary>
        void CheckIsFinishedAskingAndUpdate();
    }
}