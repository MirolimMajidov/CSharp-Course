using BankManagementSystem.Models;
using BankManagementSystem.Server.NUnit.IntegrationTests.CommonData;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BankManagementSystem.Server.NUnit.IntegrationTests.Tests
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
        public async Task GetItemById_ShouldNotReturnWorkerByInvalidId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var _client = Server.CreateClient();

            // Act
            var response = await _client.GetAsync($"Worker/GetItemById?id={id}");

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        private async Task<Guid> GetFirstWorkerId()
        {
            var _client = Server.CreateClient();
            var response = await _client.GetAsync("/Worker/AllItems");
            response.EnsureSuccessStatusCode();
            var workers = await response.Content.ReadFromJsonAsync<IEnumerable<Worker>>();
            return workers.First().Id;
        }

        [Test]
        public async Task GetItemById_ShouldReturnWorkerById()
        {
            // Arrange
            var id = await GetFirstWorkerId();
            var _client = Server.CreateClient();

            // Act
            var response = await _client.GetAsync($"Worker/GetItemById?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var worker = await response.Content.ReadFromJsonAsync<Worker>();
            Assert.That(worker, Is.Not.Null);
            Assert.That(worker.Id, Is.EqualTo(id));
        }

        [Test]
        public async Task Post_ShouldNotCreateNewWorker()
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
        public async Task Post_ShouldCreateNewWorker()
        {
            // Arrange
            var _client = Server.CreateClient();
            var newWorker = new Worker
            {
                FirstName = "Test",
                LastName = "Worker",
                Age = 35
            };

            // Act
            var response = await _client.PostAsJsonAsync("/Worker/Create", newWorker);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdWorker = await response.Content.ReadFromJsonAsync<Worker>();
            Assert.That(createdWorker, Is.Not.Null);
            Assert.That(newWorker.FirstName, Is.EqualTo(createdWorker.FirstName));
        }

        [Test]
        public async Task Put_ShouldNotUpdateByInvalidId()
        {
            // Arrange
            var _client = Server.CreateClient();
            var workerId = Guid.NewGuid();
            var updateWorker = new Worker
            {
                FirstName = "Updated",
                LastName = "Worker",
                Age = 40
            };

            // Act
            var response = await _client.PutAsJsonAsync($"/Worker/Update?id={workerId}", updateWorker);

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task Put_ShouldUpdateByValidId()
        {
            // Arrange
            var _client = Server.CreateClient();
            var workerId = await GetFirstWorkerId();
            var updateWorker = new Worker
            {
                FirstName = "Updated",
                LastName = "Worker",
                Age = 40
            };

            // Act
            var response = await _client.PutAsJsonAsync($"/Worker/Update?id={workerId}", updateWorker);

            // Assert
            response.EnsureSuccessStatusCode();
            var message = await response.Content.ReadAsStringAsync();
            Assert.That("Successfully updated", Is.EqualTo(message));
        }

        [Test]
        public async Task Delete_ShouldNotDeleteWorkerByInvalidId()
        {
            // Arrange
            var _client = Server.CreateClient();
            var workerId = Guid.NewGuid();

            // Act
            var response = await _client.DeleteAsync($"/Worker/Delete?id={workerId}");

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task Delete_ShouldDeleteWorkerByValidId()
        {
            // Arrange
            var _client = Server.CreateClient();
            var workerId = await GetFirstWorkerId();

            // Act
            var response = await _client.DeleteAsync($"/Worker/Delete?id={workerId}");

            // Assert
            response.EnsureSuccessStatusCode();
            var message = await response.Content.ReadAsStringAsync();
            Assert.That("Successfully deleted", Is.EqualTo(message));
        }
    }
}
