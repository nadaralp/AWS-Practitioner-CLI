using AWS.Practicing.Common;
using AWS.Practicing.Domain.Interfaces;
using AWS.Practicing.Domain.Models;
using AWS.Practicing.Services.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Insturctions
{
    public class Instructor : IInstructor
    {
        private bool _isFinishedAsking = false;

        public InstructionReplyModel InstructionReplyModel { get; private set; }

        public IOptionsManager OptionsManager
        {
            get
            {
                return OptionsFactory.GetOptionsManager(InstructionReplyModel);
            }
        }

        public bool IsFinishedAsking
        {
            get
            {
                return _isFinishedAsking;
            }
        }

        public Instructor()
        {
            InstructionReplyModel = new InstructionReplyModel();
        }

        public InstructionReplyModel Ask()
        {
            foreach (OptionsSchema optionSchema in OptionsManager.Options)
            {
                ConsoleUtils.WriteLine($"{optionSchema.Key}: {optionSchema.Description}");
            }
            string response = Console.ReadLine();
            InstructionReplyModel.Update(response);
            return InstructionReplyModel;
        }

        public void CheckIsFinishedAskingAndUpdate()
        {
            try
            {
                OptionsManager.Options.Any();
            }
            catch
            {
                InstructionReplyModel.RevertStep(); // need to revert 1 back because EnsureValidResponse() increments always.
                _isFinishedAsking = true;
            }
        }
    }
}