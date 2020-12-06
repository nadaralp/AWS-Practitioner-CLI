using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Models
{
    public class InstructionReplyModel
    {
        public static string EmptyResponse = "NONE";

        public string Response { get; private set; }
        public short Step { get; private set; }
        public string ExecutionHistoryPath { get; private set; }

        public InstructionReplyModel()
        {
            Response = EmptyResponse;
            Step = 0;
            ExecutionHistoryPath = string.Empty;
        }

        public InstructionReplyModel(string response, short step, string executionHistoryPath)
        {
            Response = response;
            Step = step;
            ExecutionHistoryPath = executionHistoryPath;
        }

        public void UpdateStep()
        {
            Step++;
        }

        public void UpdateResponse(string response)
        {
            UpdateExecutionHistoryPath(response);
            Response = response;
        }

        public void RevertStep()
        {
            Step--;
        }

        #region Private methods

        public void UpdateExecutionHistoryPath(string response)
        {
            if (ExecutionHistoryPath == string.Empty)
            {
                ExecutionHistoryPath += response;
                return;
            }

            ExecutionHistoryPath += $"_{response}";
        }

        #endregion Private methods
    }
}