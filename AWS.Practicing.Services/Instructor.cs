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
        private bool _isFinishedAsking = false;

        public InstructionReplyModel InstructionReplyModel { get; private set; }
        public InstructionsOptionsGraph InstructionsOptionsGraph { get; }

        public Instructor(string instructionsPath)
        {
            _instructionsPath = instructionsPath;
            InstructionReplyModel = new InstructionReplyModel(InstructionReplyModel.EmptyResponse, 0);
            InstructionsOptionsGraph = GetInstructionOptionsGraphFromJsonFile();
        }

        public string Ask()
        {
            InstructionOption currentInstruction = GetCurrentInstruction;
            ConsoleUtils.YellowWriteLine(currentInstruction.Instruction);
            foreach (InstructionOption.OptionsSchema optionSchema in currentInstruction.Options)
            {
                ConsoleUtils.WriteLine($"{optionSchema.Key}: {optionSchema.Description}");
            }
            string response = Console.ReadLine();
            return response;
        }

        public bool IsFinishedAsking
        {
            get
            {
                return _isFinishedAsking;
            }
        }

        /// <summary>
        /// This function should always be called after EnsureValidResponse.
        /// This way the logic is valid. This can produce bugs if called in different order
        /// </summary>
        public void CheckIsFinishedAskingAndUpdate()
        {
            try
            {
                InstructionOption instructionOption = GetCurrentInstruction;
            }
            catch
            {
                InstructionReplyModel.Step--; // need to revert 1 back because EnsureValidResponse() increments always.
                _isFinishedAsking = true;
            }
        }

        /// <summary>
        /// Ensures a valid response from the user. Otherwise throws
        /// </summary>
        /// <exception cref="ArgumentException"
        public void EnsureValidResponse(string response)
        {
            InstructionOption currentInstruction = GetCurrentInstruction;
            IEnumerable<string> optionalKeys = currentInstruction.Options.Select(o => o.Key.ToLower());

            if (!optionalKeys.Contains(response.ToLower()))
            {
                throw new ArgumentException("There is no such option.");
            }

            UpdateInstructionReplyModel(response);
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

        private void UpdateInstructionReplyModel(string response)
        {
            InstructionReplyModel.Step++;
            InstructionReplyModel.Response = response;
        }

        private InstructionOption GetCurrentInstruction
         =>
            InstructionsOptionsGraph[InstructionReplyModel];

        #endregion Private methods - helpers
    }
}