﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.Repository.lmpl
{
    public  class FailRepository: BaseRepository<Fail> , IFailRepository
    {
        public FailRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
