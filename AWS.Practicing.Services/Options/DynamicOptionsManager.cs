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
    public class DynamicOptionsManager : BaseOptionsManager, IDynamicOptionsManager, IOptionsManager
    {
        public DynamicOptionsManager(InstructionReplyModel instructionReplyModel) : base(instructionReplyModel)
        {
        }

        public override ICollection<OptionsSchema> Options
            => DynamicOptions.GetDynamicOptions();

        public IDynamicOptionsCommand DynamicOptions => throw new NotImplementedException();
    }
}