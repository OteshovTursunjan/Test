using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.TestSession
{
    public  class ExamSessionModel
    {
        public Guid SessionId { get; set; }
        public Guid ExamId { get; set; }
        public string SubjectName { get; set; }
        public int TotalQuestions { get; set; }
        public List<ExamQuestionDTO> Questions { get; set; }
    }
}
