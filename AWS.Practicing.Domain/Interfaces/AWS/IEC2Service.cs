using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces.AWS
{
    public interface IEC2Service
    {
        Task StartInstance(string instanceId);

        Task StopInstance(string instanceId);

        Task StopAllInstances();

        Task StartAllInstances();
    }
}