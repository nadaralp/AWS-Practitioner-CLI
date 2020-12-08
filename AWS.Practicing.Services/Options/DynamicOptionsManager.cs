using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Interfaces.DynamicOptions;
using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services
{
    public class DynamicOptionsManager : BaseOptionsManager, IOptionsManager
    {
        public string OptionsDynamicExecutorFullPath { get; }

        public DynamicOptionsManager(InstructionReplyModel instructionReplyModel, string optionsDynamicExecutorFullPath) : base(instructionReplyModel)
        {
            OptionsDynamicExecutorFullPath = optionsDynamicExecutorFullPath;
        }

        public override ICollection<OptionsSchema> Options
        {
            get
            {
                // cache that unless new dynamic options manager created -> prevent reflection work
                IDynamicOptionsCommand dynamicOptionsCommand = ReflectionUtils.CreateExecutor<IDynamicOptionsCommand>(OptionsDynamicExecutorFullPath);
                return dynamicOptionsCommand.GetDynamicOptions().GetAwaiter().GetResult();
            }
        }
    }
}