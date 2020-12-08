using AWS.Practicing.Domain.Models.DynamicOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces.DynamicOptions
{
    public interface IDynamicOptionsParamsHolder
    {
        Dictionary<string, DynamicOptionParamValues> AllKeysParamsValue { get; }

        DynamicOptionParamValues GetParamValuesByKey(string key);

        void AddParamValues(DynamicOptionParamValues dynamicOptionParamValues, DynamicOptionParamRule dynamicOptionParamRule);

        /**todo: remove that comment after completion
         * Usage
         * DynamicOptionParamValues dynamicOptionParamValues = IDynamicOptionsParamHolder.GetParamValuesByKey("a");
         * string instanceId = dynamicOptionParamValues.GetParamValue<string>("instanceId");
         *
         *Tasks:
         *1. Create a concrete implementation
         *2. Create a singleton instance of that (can we create dynamic static singleton wrapper?)
         *3. Get the singleton insdie the DynamicOptions command builder - currently have to inject manually
         *4. Add the options to the options
         *5. Execute a single command with printing the values
         * */
    }
}