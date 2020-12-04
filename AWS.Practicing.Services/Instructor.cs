using AWS.Practicing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services
{
    public class Instructor : IInstructor
    {
        public bool IsFinishedAsking => throw new NotImplementedException();

        public string Ask()
        {
            throw new NotImplementedException();
        }

        public void EnsureValidResponse(string response)
        {
            throw new NotImplementedException();
        }

        public bool IsValidResponse(string response)
        {
            throw new NotImplementedException();
        }
    }
}