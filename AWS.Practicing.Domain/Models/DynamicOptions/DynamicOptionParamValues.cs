using AWS.Practicing.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AWS.Practicing.Domain.Models.DynamicOptions
{
    public class DynamicOptionParamValues
    {
        public string Key { get; set; }
        public Dictionary<string, (object value, PrimitiveType type)> ParamsDictionary { get; }

        public T GetParamValue<T>(string paramName)
        {
            (object value, PrimitiveType type) = ParamsDictionary[paramName];
            if (typeof(T).Name != $"System.{type}")
            {
                throw new ArgumentException($"{paramName} is not stored as type {typeof(T)}");
            }

            return (T)value;
        }
    }
}