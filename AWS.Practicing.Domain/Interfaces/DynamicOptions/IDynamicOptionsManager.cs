using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces.DynamicOptions
{
    public interface IDynamicOptionsManager : IOptionsManager
    {
        IDynamicOptionsCommand DynamicOptions { get; }
    }
}