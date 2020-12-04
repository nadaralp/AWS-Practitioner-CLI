using System.Collections.Generic;

namespace AWS.Practicing.Domain.Models
{
    public class InstructionExecutorsOptions
    {
        public List<ExecutorInfo> Executors { get; set; }

        public class ExecutorInfo
        {
            public string Key { get; set; }
            public string ExecutorFullPath { get; set; }
        }
    }
}