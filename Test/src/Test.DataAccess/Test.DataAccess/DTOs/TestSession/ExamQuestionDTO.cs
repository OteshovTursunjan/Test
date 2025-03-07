using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.TestSession
{
    public  class ExamQuestionDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public AnswerOptionDTO Answers { get; set; }
    }
}
