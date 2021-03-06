﻿using AWS.Practicing.Common;
using AWS.Practicing.Domain.Exceptions;
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

        /// <summary>
        /// Get's the instruction command based on the execution history path.
        /// </summary>
        /// <exception cref="InstructionNotImplementedException"
        public IInstructionCommand GetInstructionCommand(InstructionReplyModel instructionReplyModel)
        {
            string instructionExecutorsPath = Paths.GetInstructionsExecutorsPath;
            string fileText = File.ReadAllText(instructionExecutorsPath);
            InstructionExecutorsOptions instructionExecutorsOptions = _yamlDeserizlier.Deserialize<InstructionExecutorsOptions>(fileText);

            InstructionExecutorsOptions.ExecutorInfo executorInfo =
                 instructionExecutorsOptions
                .Executors
                .FirstOrDefault(executor => executor.Key == instructionReplyModel.ExecutionHistoryPath);

            if (executorInfo is null)
            {
                throw new InstructionNotImplementedException(instructionReplyModel);
            }

            return ReflectionUtils.CreateExecutor<IInstructionCommand>(executorInfo.ExecutorFullPath);
        }
    }
}