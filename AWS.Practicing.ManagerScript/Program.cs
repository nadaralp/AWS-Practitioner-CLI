using AWS.Practicing.Common;
using AWS.Practicing.Domain;
using AWS.Practicing.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace AWS.Practicing.ManagerScript
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                ConsoleUtils.YellowConsoleWriteLine("Note: If you want to automate the process, then run the CLI with the commands args in order of steps. Exmaple: 'E' 'START'");
            }

            //foreach (var arg in args)
            //{
            //    Console.WriteLine(arg);
            //}

            IInstructor instructor = InstructorManagerRepository.GetInstructor(); //todo
            IInstructorExecutor instructorExecutor = InstructorManagerRepository.GetInstructorExecutor(instructor); //todo

            while (!instructor.IsFinishedAsking)
            {
                string response = instructor.Ask();
                instructor.EnsureValidResponse(response);
                await instructorExecutor.ExecuteInstruction(response);
            }
        }
    }
}