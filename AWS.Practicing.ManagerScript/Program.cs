﻿using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Services.Repositories;
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

            //foreach (var arg in args)
            //{
            //    Console.WriteLine(arg);
            //}

            try
            {
                IInstructor instructor = InstructorManagerRepository.GetInstructor();
                //IInstructorExecutor instructorExecutor = InstructorManagerRepository.GetInstructorExecutor(instructor); //todo

                while (!instructor.IsFinishedAsking)
                {
                    string response = instructor.Ask();
                    instructor.EnsureValidResponse(response);
                    ConsoleUtils.BreakLine();

                    // Ensures there are more questions to come
                    instructor.CheckIsFinishedAskingAndUpdate();
                    //await instructorExecutor.ExecuteInstruction(response);
                }

                Console.WriteLine("Volaaaaaaa finished");
            }
            catch (Exception e)
            {
                ConsoleUtils.RedWriteLine(e.Message);
            }
        }
    }
}