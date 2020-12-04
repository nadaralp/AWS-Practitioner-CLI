using AWS.Practicing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.InstructorCommands
{
    public class EC2StartAllCommand : IInstructionCommand
    {
        public async Task Execute()
        {
            Console.WriteLine("starting all ininstances");
        }
    }
}