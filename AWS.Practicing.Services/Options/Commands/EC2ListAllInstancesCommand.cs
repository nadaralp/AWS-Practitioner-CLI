using Amazon.EC2.Model;
using AWS.Practicing.Common.Extensions;
using AWS.Practicing.Domain.Interfaces.AWS;
using AWS.Practicing.Domain.Interfaces.DynamicOptions;
using AWS.Practicing.Domain.Models;
using AWS.Practicing.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Options.Commands
{
    public class EC2ListAllInstancesCommand : IDynamicOptionsCommand
    {
        private IEC2Service EC2Service = AWSFactory.GetEC2Service();

        public async Task<ICollection<OptionsSchema>> GetDynamicOptions()
        {
            DescribeInstancesResponse descriptionResponse = await EC2Service.AmazonEC2Client.DescribeInstancesAsync();

            IEnumerable<Instance> instances = descriptionResponse.Reservations.SelectMany(r => r.Instances);
            var options = instances.Select((instance, index) => new OptionsSchema(index.ToASCII(), GetInstanceDescription(instance)));
            return options.ToList();
        }

        private string GetInstanceDescription(Instance instance)
        {
            StringBuilder description = new StringBuilder();
            description.Append($"Instance id: {instance.InstanceId}, status: {instance.State.Name.Value}, type: {instance.InstanceType.Value}");

            Tag nameTag = instance.Tags.FirstOrDefault(t => t.Key.ToLower() == "name");
            if (nameTag != null)
                description.Append($", name: {nameTag.Value}");

            return description.ToString();
        }
    }
}