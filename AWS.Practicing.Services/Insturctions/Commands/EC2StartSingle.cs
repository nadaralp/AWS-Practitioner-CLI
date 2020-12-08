using AWS.Practicing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Insturctions.Commands
{
    public class EC2StartSingle : IInstructionCommand
    {
        public async Task Execute()
        {
            Console.WriteLine("Omg it works");
        }
    }
}