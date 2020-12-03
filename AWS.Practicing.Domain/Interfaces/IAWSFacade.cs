using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain.Interfaces
{
    public interface IAWSFacade
    {
        /// <summary>
        /// Stops all the ec2 instances on the AWS default account (north-virginia region)
        /// </summary>
        Task<bool> StartAllEC2InstancesAsync();

        /// <summary>
        /// stops all the ec2 instances on the AWS default account (north-virginia region)
        /// </summary>
        Task<bool> StopAllEC2InstancesAsync();

        /// <summary>
        /// Starts all the rds instances on the AWS default account (north-virginia region)
        /// </summary>
        Task<bool> StartAllRDSInstancesAsync();

        /// <summary>
        /// stops all the rds instances on the AWS default account (north-virginia region)
        /// </summary>
        Task<bool> StopAllRDSInstancesAsync();
    }
}