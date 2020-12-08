using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Models.DynamicOptions
{
    public class DynamicOptionParamRule
    {
        private const char DELIMITER = ',';
        public Dictionary<string, bool> MustHaveParams { get; } // key-value. They key is the reply. Value indicates if param was given value.

        public bool IsValidParamsRule
            => MustHaveParams.All((kv) => kv.Value == true);

        public DynamicOptionParamRule(string paramsSeparatedString)
        {
            MustHaveParams = paramsSeparatedString.Split(DELIMITER).ToDictionary(s => s, (_) => false);
        }
    }
}