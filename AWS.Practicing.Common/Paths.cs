using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Common
{
    public static class Paths
    {
        private static string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string instructionsFolder = "Instructions";

        public static string GetInstructionsPath =>
            Path.Combine(_baseDirectory, instructionsFolder, "instructions.json");

        public static string GetInstructionsExecutorsPath =>
            Path.Combine(_baseDirectory, instructionsFolder, "instructions_executors.yaml");

        public static string ExecutorsAssemblyPath =>
            "AWS.Practicing.Services";
    }
}