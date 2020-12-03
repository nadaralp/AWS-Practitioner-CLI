using AWS.Practicing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain
{
    public class AWSFacade : IAWSFacade
    {
        public Task<bool> StartAllEC2InstancesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> StartAllRDSInstancesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> StopAllEC2InstancesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> StopAllRDSInstancesAsync()
        {
            throw new NotImplementedException();
        }
    }
}