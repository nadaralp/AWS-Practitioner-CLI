using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Interfaces.AWS;
using AWS.Practicing.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Insturctions.Commands
{
    public class EC2StopAllCommand : IInstructionCommand
    {
        private IEC2Service _eC2Service = AWSFactory.GetEC2Service();

        public async Task Execute()
        {
            await _eC2Service.StopAllInstances();
        }
    }
}