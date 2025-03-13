
using Tests.Core.Enteties;

namespace Test.DataAccess.Repository.lmpl;

public  class StaticRepository : BaseRepository<Statictis>, IStaticRepository
{
    public StaticRepository(DatabaseContext context) : base(context) { }
}
