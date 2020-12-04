using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AWS.Practicing.Services
{
    public class Instructor : IInstructor
    {
        private readonly string _instructionsPath;

        public InstructionReplyModel InstructionReplyModel { get; private set; }
        public InstructionsOptionsGraph InstructionsOptionsGraph { get; }

        public Instructor(string instructionsPath)
        {
            _instructionsPath = instructionsPath;
            InstructionReplyModel = new InstructionReplyModel(InstructionReplyModel.EmptyResponse, 0);
            InstructionsOptionsGraph = GetInstructionOptionsGraphFromJsonFile();
        }

        public bool IsFinishedAsking
        {
            get
            {
                //todo
                return false;
            }
        }

        public string Ask()
        {
            // need to get the current question.
            // and list of answers for the current question
            InstructionOption currentInstruction = InstructionsOptionsGraph[InstructionReplyModel];
            ConsoleUtils.YellowWriteLine(currentInstruction.Instruction);
            foreach (InstructionOption.OptionsSchema optionSchema in currentInstruction.Options)
            {
                ConsoleUtils.WriteLine($"{optionSchema.Key}: {optionSchema.Description}");
            }
            ConsoleUtils.BreakLine();
            string response = Console.ReadLine();
            return response;
        }

        /// <summary>
        /// Ensures a valid response from the user. Otherwise throws
        /// </summary>
        /// <exception cref="ArgumentException"
        public void EnsureValidResponse(string response)
        {
            //IEnumerable<string> optionalKeys = currentInstruction.Options.Select(o => o.Key.ToLower());

            //if (!optionalKeys.Contains(response.ToLower()))
            //{
            //    throw new ArgumentException("There is no such option.");
            //}
        }

        public bool IsValidResponse(string response)
        {
            throw new NotImplementedException();
        }

        #region Private methods - helpers

        private InstructionsOptionsGraph GetInstructionOptionsGraphFromJsonFile()
        {
            using (var streamReader = new StreamReader(_instructionsPath))
            {
                string textFromStreamReader = streamReader.ReadToEnd();
                InstructionsOptionsGraph instructionOptionsList = JsonSerializer.Deserialize<InstructionsOptionsGraph>(textFromStreamReader);
                return instructionOptionsList;
            }
        }

        #endregion Private methods - helpers
    }
}