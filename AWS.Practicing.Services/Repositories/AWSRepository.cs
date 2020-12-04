using Amazon.EC2;
using AWS.Practicing.Domain.Interfaces.AWS;
using AWS.Practicing.Services.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Services.Repositories
{
    public class AWSRepository
    {
        public static IEC2Service GetEC2Service()
        {
            var amazonEC2Cleint = new AmazonEC2Client();
            return new EC2Service(amazonEC2Cleint);
        }
    }
}