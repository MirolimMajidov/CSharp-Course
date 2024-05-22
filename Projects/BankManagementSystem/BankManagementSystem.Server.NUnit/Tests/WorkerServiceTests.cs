using BankManagementSystem.Models;
using BankManagementSystem.Server.NUnit.UnitTests.CommonData;
using NSubstitute;
using NUnit.Framework;

namespace BankManagementSystem.Server.NUnit.UnitTests.Tests;

public class WorkerServiceTests : BaseTestEntity
{
    [Test]
    public void GetAll_ShouldReturnAllWorkers()
    {
        // Arrange
        var workers = new List<Worker> { new Worker { FirstName = "John", LastName = "Doe" } }.AsQueryable();
        _repository.GetAll().Returns(workers);

        // Act
        var result = _workerService.GetAll();

        // Assert
        Assert.That(result, Is.EqualTo(workers));
    }

    [Test]
    public async Task GetById_ShouldReturnWorker_WhenWorkerExists()
    {
        // Arrange
        var worker = new Worker { FirstName = "John", LastName = "Doe" };
        _repository.GetById(worker.Id).Returns(Task.FromResult(worker));

        // Act
        var result = await _workerService.GetById(worker.Id);

        // Assert
        Assert.That(result, Is.EqualTo(worker));
    }

    [Test]
    public void TryCreate_ShouldReturnErrorMessage_WhenFirstNameOrLastNameIsEmpty()
    {
        // Arrange
        var worker = new Worker { FirstName = "", LastName = "Doe" };
        string message;

        // Act
        var result = _workerService.TryCreate(worker, out message);

        // Assert
        Assert.That(result, Is.Null);
        Assert.That(message, Is.EqualTo("The first name or last name is be empty"));
    }

    [Test]
    public void TryCreate_ShouldCreateWorker_WhenFirstNameAndLastNameAreProvided()
    {
        // Arrange
        var worker = new Worker { FirstName = "John", LastName = "Doe" };
        _repository.TryCreate(worker, out Arg.Any<string>()).Returns(worker);

        // Act
        var result = _workerService.TryCreate(worker, out string message);

        // Assert
        Assert.That(result, Is.EqualTo(worker));
        Assert.That(message, Is.Null);
    }

    [Test]
    public void TryUpdate_ShouldReturnFalse_WhenWorkerNotFound()
    {
        // Arrange
        var workerId = Guid.NewGuid();
        var worker = new Worker { FirstName = "John", LastName = "Doe" };
        _repository.GetById(workerId).Returns(Task.FromResult((Worker)null));

        // Act
        var result = _workerService.TryUpdate(workerId, worker, out string message);

        // Assert
        Assert.That(result, Is.False);
        Assert.That(message, Is.EqualTo("Item not found"));
    }

    [Test]
    public void TryUpdate_ShouldUpdateWorker_WhenWorkerIsFound()
    {
        // Arrange
        var existingWorker = new Worker { FirstName = "John", LastName = "Doe" };
        var updatedWorker = new Worker { FirstName = "Jane", LastName = "Smith" };
        _repository.GetById(existingWorker.Id).Returns(Task.FromResult(existingWorker));
        _repository.TryUpdate(existingWorker, out Arg.Any<string>()).Returns(true);

        // Act
        var result = _workerService.TryUpdate(existingWorker.Id, updatedWorker, out string message);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(message, Is.Null);
        Assert.That(existingWorker.FirstName, Is.EqualTo("Jane"));
        Assert.That(existingWorker.LastName, Is.EqualTo("Smith"));
    }

    [Test]
    public void TryDelete_ShouldDeleteWorker_WhenWorkerIsFound()
    {
        // Arrange
        var workerId = Guid.NewGuid();
        _repository.TryDelete(workerId, out Arg.Any<string>()).Returns(true);

        // Act
        var result = _workerService.TryDelete(workerId, out string message);

        // Assert
        Assert.That(result, Is.True);
        Assert.That(message, Is.Null);
    }
}
