using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Core.Enteties
{
    public  class ExamLog
    {
        public Guid id { get; set; }
        public DateTime? CreateAt { get; set; }
        public ExamAttempt ExamAttempts { get; set; }
        public Guid AtemptID { get; set; }
        public string action { get; set; }
    }
}
