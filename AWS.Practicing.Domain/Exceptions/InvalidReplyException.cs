using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Exceptions
{
    public class InvalidReplyException : Exception
    {
        public InvalidReplyException(InstructionReplyModel instructionReplyModel)
            : base($"{instructionReplyModel.Response} is an invalid response for step {instructionReplyModel.Step + 1}")
        {
        }
    }
}