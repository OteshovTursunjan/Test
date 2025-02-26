﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.DTOs.Creation;

public class QuestionCreationModel
{
    public Guid ExamId { get; set; }
    public Exam Exams { get; set; }

    public string Text { get; set; }

    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string D { get; set; }
    public string RightAnswer { get; set; }  // Навигационное свойство (без FK!)

}
