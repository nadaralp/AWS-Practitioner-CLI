using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using AWS.Practicing.Services.Factories;
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
                ConsoleUtils.YellowWriteLine("Note: If you want to automate the process, then run the CLI with the commands args in the order of steps. Exmaple: 'E' 'START' \n\n");
            }

            try
            {
                IInstructor instructor = InstructorManagerFactory.GetInstructor();
                IInstructorExecutor instructorExecutor = InstructorManagerFactory.GetInstructorExecutor(instructor);

                while (!instructor.IsFinishedAsking)
                {
                    InstructionReplyModel response = instructor.Ask();
                    instructor.OptionsManager.EnsureValidResponse(response);
                    ConsoleUtils.BreakLine();

                    instructor.CheckIsFinishedAskingAndUpdate();
                }

                await instructorExecutor.ExecuteInstruction();
            }
            catch (Exception e)
            {
                ConsoleUtils.RedWriteLine(e.Message);
            }
        }
    }
}