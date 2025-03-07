using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.Repository.lmpl;

public class ExamSessionRepository : BaseRepository<ExamSession>, IExamSessionRepository
{
    public ExamSessionRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
