using NSubstitute;
using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using BankManagementSystem.Services;
using BankManagementSystem.Models;

namespace BankManagementSystem.Server.NUnit;

public class WorkerServiceTests
{
    private IWorkerService _workerService;
    private ISQLRepository<Worker> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = Substitute.For<ISQLRepository<Worker>>();
        _workerService = new WorkerService(_repository);
    }

    [Test]
    public void GetAll_ShouldReturnAllWorkers()
    {
        // Arrange
        var workers = new List<Worker> { new Worker { FirstName = "John", LastName = "Doe" } }.AsQueryable();
        _repository.GetAll().Returns(workers);

        // Act
        var result = _workerService.GetAll();

        // Assert
        Assert.AreEqual(workers, result);
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
        Assert.AreEqual(worker, result);
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
        Assert.IsNull(result);
        Assert.AreEqual("The first name or last name is be empty", message);
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
        Assert.AreEqual(worker, result);
        Assert.IsNull(message);
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
        Assert.IsFalse(result);
        Assert.AreEqual("Item not found", message);
    }

    [Test]
    public void TryUpdate_ShouldUpdateWorker_WhenWorkerIsFound()
    {
        // Arrange
        var existingWorker = new Worker {FirstName = "John", LastName = "Doe" };
        var updatedWorker = new Worker { FirstName = "Jane", LastName = "Smith" };
        _repository.GetById(existingWorker.Id).Returns(Task.FromResult(existingWorker));
        _repository.TryUpdate(existingWorker, out Arg.Any<string>()).Returns(true);

        // Act
        var result = _workerService.TryUpdate(existingWorker.Id, updatedWorker, out string message);

        // Assert
        Assert.IsTrue(result);
        Assert.IsNull(message);
        Assert.AreEqual("Jane", existingWorker.FirstName);
        Assert.AreEqual("Smith", existingWorker.LastName);
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
        Assert.IsTrue(result);
        Assert.IsNull(message);
    }
}
