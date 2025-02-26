using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.DTOs.Creation
{
    public  class ExamAttemptCreationModel
    {
        public int NumberOfAttempt { get; set; }
        public ApplicationUser User { get; set; }
        public Guid StudentId { get; set; }
        public Exam Exams { get; set; }
        public Guid ExamId { get; set; }
        public int Score { get; set; }
    }
}
