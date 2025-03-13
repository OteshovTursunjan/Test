

using Tests.Core.Enteties;

namespace Test.DataAccess.Repository.lmpl;

public  class StudentAttemptRepository : BaseRepository<StudentAttempt>, IStudentAttemptRepository
{
    public StudentAttemptRepository(DatabaseContext databaseContext) : base(databaseContext) { }
}
