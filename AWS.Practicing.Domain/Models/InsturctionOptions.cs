using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Models
{
    public class InsturctionOptionslist
    {
        public ICollection<InsturctionOptions> Insturctions { get; set; }
    }

    public class InsturctionOptions
    {
        public string Trigger { get; set; }
        public string Command { get; set; }
        public ICollection<OptionsSchema> Options { get; set; }

        public class OptionsSchema
        {
            public string Key { get; set; }
            public string Description { get; set; }
        }
    }
}