using AWS.Practicing.Domain.Interfaces.DynamicOptions;
using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Options.Commands
{
    public class EC2ListAllInstancesCommand : IDynamicOptionsCommand
    {
        public ICollection<OptionsSchema> GetDynamicOptions()
        {
            var ret = new List<OptionsSchema>();

            ret.Add(new OptionsSchema { Key = "a", Description = "test" });
            ret.Add(new OptionsSchema { Key = "b", Description = "test-abc" });
            ret.Add(new OptionsSchema { Key = "c", Description = "test-caca" });
            ret.Add(new OptionsSchema { Key = "d", Description = "test-dandy" });

            return ret;
        }
    }
}