using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.Repository.lmpl
{
    public  class StudentResultRepository : BaseRepository<StudentResult>,IStudentResultRepository
    {
        public StudentResultRepository(DatabaseContext database) : base(database) { }
    }
}
