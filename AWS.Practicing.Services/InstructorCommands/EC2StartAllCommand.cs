using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Interfaces.AWS;
using AWS.Practicing.Services.AWS;
using AWS.Practicing.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.InstructorCommands
{
    public class EC2StartAllCommand : IInstructionCommand
    {
        private IEC2Service _eC2Service = AWSRepository.GetEC2Service();

        public async Task Execute()
        {
            await _eC2Service.StartAllInstances();
        }
    }
}