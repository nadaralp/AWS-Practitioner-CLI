using Amazon.EC2;
using Amazon.EC2.Model;
using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.AWS
{
    public class EC2Service : IEC2Service
    {
        private IAmazonEC2 _amazonEC2Client;

        public EC2Service(IAmazonEC2 amazonEC2)
        {
            _amazonEC2Client = amazonEC2;
        }

        public async Task StartAllInstances()
        {
            var instancesDescription = await _amazonEC2Client.DescribeInstancesAsync();
            var instancesToStartId = new List<string>();

            foreach (var reservation in instancesDescription.Reservations)
            {
                foreach (var instance in reservation.Instances)
                {
                    ConsoleUtils.GreenWriteLine($"Starting instance: {instance.InstanceId}");
                    instancesToStartId.Add(instance.InstanceId);
                }
            }

            StartInstancesRequest startInstancesRequest = new StartInstancesRequest(instancesToStartId);
            var response = await _amazonEC2Client.StartInstancesAsync(startInstancesRequest);
            Console.WriteLine($"Status Code: {response.HttpStatusCode}");
        }

        public Task StartInstance(string instanceId)
        {
            throw new NotImplementedException();
        }

        public async Task StopAllInstances()
        {
            var instancesDescription = await _amazonEC2Client.DescribeInstancesAsync();
            var instancesToStopId = new List<string>();

            foreach (var reservation in instancesDescription.Reservations)
            {
                foreach (var instance in reservation.Instances)
                {
                    ConsoleUtils.RedWriteLine($"Stopping instance: {instance.InstanceId}");
                    instancesToStopId.Add(instance.InstanceId);
                }
            }

            StopInstancesRequest stopInstancesRequest = new StopInstancesRequest(instancesToStopId);
            var response = await _amazonEC2Client.StopInstancesAsync(stopInstancesRequest);
            Console.WriteLine($"Status Code: {response.HttpStatusCode}");
        }

        public Task StopInstance(string instanceId)
        {
            throw new NotImplementedException();
        }
    }
}