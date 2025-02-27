using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.DTOs.Update;

public  class SubjectUpdateModel
{
    public Guid id {  get; set; }
    public string Name { get; set; }
    public Faculty Faculty { get; set; }
    public Guid FacultyID { get; set; }
}
