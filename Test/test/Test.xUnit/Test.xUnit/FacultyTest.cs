using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Faculty.Command;
using Test.Application.Feature.Faculty.Handler;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.DTOs.Update;
using Test.DataAccess.Repository;
using Tests.Core.Enteties;

namespace Test.xUnit;

public class FacultyTest
{
    [Fact]
    public async Task Handle_ShouldAddFacultyAndReturnTrue()
    {

        // Arrange
        var facultyRepositoryMock = new Mock<IFacultyRepository>();
        var facultyCreationModel = new FacultyCreationModel { Name = "Test Faculty" };
        var command = new CreateFacultyCommand(facultyCreationModel);
        var handler = new CreateFacultyHandler(facultyRepositoryMock.Object);

        facultyRepositoryMock
      .Setup(repo => repo.AddAsync(It.IsAny<Faculty>()))
      .ReturnsAsync(new Faculty());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        facultyRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Faculty>()), Times.Once);
    }
    [Fact]
    public async Task Handle_ShouldDeleteFacultyReturnTrue()
    {
        var facultyRepositoryMock = new Mock<IFacultyRepository>();
        var facultyId = Guid.NewGuid();
        var faculty = new Faculty { id  = facultyId , Name = "Test Faculty"};
        var command = new DeleteFacultyCommand(facultyId);
        var handler = new DeleteFacultyHandler(facultyRepositoryMock.Object);

        facultyRepositoryMock
     .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Faculty, bool>>>()))
     .ReturnsAsync(faculty);

        facultyRepositoryMock
     .Setup(repo => repo.DeleteAsync(It.IsAny<Faculty>()))
     .ReturnsAsync((Faculty faculty)=> faculty);

        var result = await handler.Handle(command,CancellationToken.None);

        Assert.True(result);
        facultyRepositoryMock.Verify(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Faculty, bool>>>()), Times.Once);
        facultyRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<Faculty>()), Times.Once);

    }
    [Fact]
    public async Task Handle_ShouldUpdateFacultyAndReturnTrue()
    {
        var facultyRepositoryMock = new Mock<IFacultyRepository>();
        var facultyId = Guid.NewGuid();
        var faculty = new Faculty { id = facultyId, Name = "Old Name" };
        var updateModel = new FacultyUpdateModel { id = facultyId, name = "Updated Name" };
        var updates = new Faculty { id = facultyId, Name = "Updated Name" };
        var command = new UpdateFacultyCommand(updateModel);
        var handler = new UpdateFacultyHandler(facultyRepositoryMock.Object);

        facultyRepositoryMock
            .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Faculty, bool>>>()))
            .ReturnsAsync(faculty);

        facultyRepositoryMock
      .Setup(repo => repo.UpdateAsync(It.IsAny<Faculty>()))
      .ReturnsAsync(updates); // Правильный возврат Task<Faculty>
                              // Правильный возврат Task

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        Assert.Equal("Updated Name", faculty.Name);
        facultyRepositoryMock.Verify(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Faculty, bool>>>()), Times.Once);
        facultyRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Faculty>()), Times.Once);
    }
}
