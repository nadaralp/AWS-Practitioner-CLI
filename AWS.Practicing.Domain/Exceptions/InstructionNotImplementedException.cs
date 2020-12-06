using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Exceptions
{
    public class InstructionNotImplementedException : Exception
    {
        public InstructionNotImplementedException(InstructionReplyModel instructionReplyModel) : base($"{instructionReplyModel.ExecutionHistoryPath} has no executor implementation")
        {
        }
    }
}