using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.DTOs.Creation;

public class SubjectCreationModel
{
    public string Name { get; set; }
  
    public Guid FacultyID { get; set; }
}
