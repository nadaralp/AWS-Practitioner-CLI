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

        private IOptionsManager _optionsManager;

        public IOptionsManager OptionsManager
        {
            get
            {
                return _optionsManager;
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
            GetNewOptionsManagerBasedOnReplyModel();

            foreach (OptionsSchema optionSchema in OptionsManager.Options)
            {
                ConsoleUtils.WriteLine($"{optionSchema.Key}: {optionSchema.Description}");
            }
            string response = Console.ReadLine();
            InstructionReplyModel.UpdateResponse(response);
            return InstructionReplyModel;
        }

        public void CheckIsFinishedAskingAndUpdate()
        {
            if (OptionsManager.HasOptionExecutorForHistoryPath(InstructionReplyModel))
                _isFinishedAsking = true;
        }

        #region Private Methods

        private void GetNewOptionsManagerBasedOnReplyModel()
        {
            _optionsManager = OptionsFactory.GetOptionsManager(InstructionReplyModel);
        }

        #endregion Private Methods
    }
}