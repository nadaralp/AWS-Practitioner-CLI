using AWS.Practicing.Common;
using AWS.Practicing.Domain.Models;
using System.IO;
using System.Text.Json;

namespace AWS.Practicing.Services
{
    public static class OptionsHelper
    {
        public static InstructionsOptionsGraph GetInstructionOptionsGraphFromJsonFile()
        {
            string instructionsPath = PathHelpers.GetInstructionsPath;

            using (var streamReader = new StreamReader(instructionsPath))
            {
                string textFromStreamReader = streamReader.ReadToEnd();
                InstructionsOptionsGraph instructionOptionsList = JsonSerializer.Deserialize<InstructionsOptionsGraph>(textFromStreamReader);
                return instructionOptionsList;
            }
        }
    }
}