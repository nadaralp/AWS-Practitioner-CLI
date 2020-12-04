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

        public string Response { get; set; }
        public short Step { get; set; }

        public InstructionReplyModel(string response, short step)
        {
            Response = response;
            Step = step;
        }
    }
}