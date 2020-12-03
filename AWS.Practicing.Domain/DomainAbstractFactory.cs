using AWS.Practicing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Domain
{
    public class DomainAbstractFactory
    {
        public static IInstructor GetInstructor()
        {
            // string instructionsPath = app domain directory -> always copy;
            // return new Instructor();
            throw new NotImplementedException();
        }

        public static IInstructorExecutor GetInstructorExecutor(IInstructor instructor)
        {
            throw new NotImplementedException();
        }
    }
}