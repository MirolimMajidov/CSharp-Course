using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using System.Text.Json;

namespace BankManagementSystem.Server.NUnit.IntegrationTests
{
    internal class WorkerControllerTests : BaseTestEntity
    {
        [Test]
        public async Task GetAll_ShouldReturnAllWorkers()
        {
            // Arrange
            var _client = Server.CreateClient();

            // Act
            var response = await _client.GetAsync("Worker/AllItems");

            // Assert
            response.EnsureSuccessStatusCode();
            var workers = await response.Content.ReadFromJsonAsync<IEnumerable<Worker>>();
            Assert.That(workers.Any(), Is.True);
        }

        [Test]
        public async Task GetItemById_ShouldReturnWorkerById_IdIsInvalid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var _client = Server.CreateClient();

            // Act
            var response = await _client.GetAsync($"Worker/GetItemById?id={id}");

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task GetItemById_ShouldReturnWorkerById_ValidId()
        {
            // Arrange
            var _client = Server.CreateClient();
            var createdWorker = await CreateNewWorker();

            // Act
            var response = await _client.GetAsync($"Worker/GetItemById?id={createdWorker.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var worker = await response.Content.ReadFromJsonAsync<Worker>();
            Assert.That(worker, Is.Not.Null);
            Assert.That(worker.Id, Is.EqualTo(createdWorker.Id));
        }

        async Task<Worker> CreateNewWorker()
        {
            var _client = Server.CreateClient();
            var newWorker = new Worker { FirstName = "Test", LastName = "Test" };
            var content = new StringContent(JsonSerializer.Serialize(newWorker), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("Worker/Create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Worker>();
        }

        [Test]
        public async Task Post_ShouldCreateNewWorker_NewWorkerIsNotValid()
        {
            // Arrange
            var _client = Server.CreateClient();
            var newWorker = new Worker { };
            var content = new StringContent(JsonSerializer.Serialize(newWorker), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("Worker/Create", content);

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task Post_ShouldCreateNewWorker_NewWorkerIsValid()
        {
            // Arrange
            var _client = Server.CreateClient();
            var newWorker = new Worker { FirstName = "Test", LastName = "Test" };
            var content = new StringContent(JsonSerializer.Serialize(newWorker), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("Worker/Create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdWorker = await response.Content.ReadFromJsonAsync<Worker>();
            Assert.That(createdWorker, Is.Not.Null);
        }
    }
}
