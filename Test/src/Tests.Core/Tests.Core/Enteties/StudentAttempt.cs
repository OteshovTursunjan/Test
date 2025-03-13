using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties;

public class StudentAttempt : BaseEntity
{
    public int Attempts { get; set; }   
    public Guid StudentID {  get; set; } 
}
