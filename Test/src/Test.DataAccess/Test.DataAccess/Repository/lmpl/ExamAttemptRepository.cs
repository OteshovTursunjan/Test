using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.Repository.lmpl;

public  class ExamAttemptRepository : BaseRepository<ExamAttempt>,IExamAttemptRepository
{
    public ExamAttemptRepository(DatabaseContext context): base(context) { }
}
