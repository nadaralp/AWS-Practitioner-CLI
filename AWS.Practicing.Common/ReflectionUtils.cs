using AWS.Practicing.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Common
{
    public class ReflectionUtils
    {
        public static T CreateExecutor<T>(string executorFullPath) where T : class
        {
            string assemblyString = Paths.ExecutorsAssemblyPath;
            Assembly assembly = Assembly.Load(assemblyString);
            T instance = assembly.CreateInstance(executorFullPath) as T;
            if (instance is null)
            {
                throw new InvalidExecutorException<T>();
            }
            return instance;
        }
    }
}