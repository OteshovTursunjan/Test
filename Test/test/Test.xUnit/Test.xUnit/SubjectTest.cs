using Moq;
using System;
using System.Linq.Expressions;
using Test.Application.Feature.Faculty.Command;
using Test.Application.Feature.Faculty.Handler;
using Test.Application.Feature.Subject.Command;
using Test.Application.Feature.Subject.Handler;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.DTOs.Update;
using Test.DataAccess.Repository;
using Tests.Core.Enteties;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.xUnit;

public  class SubjectTest
{
   
    [Fact]
    public async Task DeleteSubjectReturnTrue()
    {
        var subjectRepositoryMock = new Mock<ISubjectRepository>();
        var subject = new Subject { id = Guid.NewGuid(), Name = "TT" };
        var command = new DeleteSubjectCommand(subject.id);
        var handler = new DeleteSubjectHandler(subjectRepositoryMock.Object);


       subjectRepositoryMock.Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Subject, bool>>>())).
            ReturnsAsync(subject);

     subjectRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<Subject>())).ReturnsAsync((Subject subject) => subject);


        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);
        subjectRepositoryMock.Verify(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Subject,bool>>>()), Times.Once);
        subjectRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<Subject>()), Times.Once);

     
    }




    [Fact]
    public async Task UpdateSubjectShoudlReturnTrue()
    {
        var subjectrepositoryMock = new Mock<ISubjectRepository>();
        var oldsubject = new Subject() { id =  Guid.NewGuid(), Name = "OldName", FacultyID = Guid.NewGuid() };
        var updateSubjectModel = new SubjectUpdateModel() { FacultyID = Guid.NewGuid(), id = Guid.NewGuid(), Name = "All" };
        var newsubject = new Subject() { id = updateSubjectModel.id, FacultyID = updateSubjectModel.FacultyID, Name = updateSubjectModel.Name };
        var command = new UpdateSubjectCommand(updateSubjectModel);
        var handler = new UpdateSubjectHandler(subjectrepositoryMock.Object);

        subjectrepositoryMock.
            Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Subject, bool>>>())).
            ReturnsAsync(oldsubject);

        subjectrepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Subject>())).ReturnsAsync(newsubject);


        var result = await handler.Handle(command, CancellationToken.None);


        Assert.True(result);
        Assert.Equal("All", oldsubject.Name);
        subjectrepositoryMock.Verify(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Subject, bool>>>()), Times.Once);
        subjectrepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Subject>()), Times.Once );

    }
}
