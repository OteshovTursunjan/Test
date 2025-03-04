using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.DTOs.Update
{
    public  class UpdateExamAttempt
    {
       
        public Guid StudentId { get; set; }
        public int NumberOfAttempt { get; set; }
    }
}
