using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using AWS.Practicing.Services.Insturctions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using YamlDotNet.Serialization;

namespace AWS.Practicing.Services.Factories
{
    public class InstructionCommandFactory
    {
        private IDeserializer _yamlDeserizlier = new Deserializer();

        public IInstructionCommand GetInstructionCommand(InstructionReplyModel instructionReplyModel)
        {
            string instructionExecutorsPath = PathHelpers.GetInstructionsExecutorsPath;
            string fileText = File.ReadAllText(instructionExecutorsPath);
            InstructionExecutorsOptions instructionExecutorsOptions = _yamlDeserizlier.Deserialize<InstructionExecutorsOptions>(fileText);

            InstructionExecutorsOptions.ExecutorInfo executorInfo =
                 instructionExecutorsOptions
                .Executors
                .FirstOrDefault(executor => executor.Key == instructionReplyModel.ExecutionHistoryPath);

            if (executorInfo is null)
            {
                throw new NotImplementedException($"{instructionReplyModel.ExecutionHistoryPath} has no executor implementation");
            }

            return CreateExecutor(executorInfo.ExecutorFullPath);
        }

        private IInstructionCommand CreateExecutor(string executorFullPath)
        {
            // change reflection - don't hard code instructor
            Assembly assembly = typeof(Instructor).Assembly;
            IInstructionCommand instance = assembly.CreateInstance(executorFullPath) as IInstructionCommand;
            return instance;
        }
    }
}