using AWS.Practicing.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace AWS.Practicing.ManagerScript
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            IInstructor instructor = null; //instantiate
            IInstructorExecutor instructorExecutor = null; //instantiate

            while (!instructor.IsFinishedAsking)
            {
                string response = instructor.Ask();
                instructor.EnsureValidResponse(response);
                await instructorExecutor.ExecuteInstruction(response);
            }
        }
    }
}