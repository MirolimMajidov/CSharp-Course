using BankManagementSystem.Models;
using BankManagementSystem.Services;
using NSubstitute;
using NUnit.Framework;

namespace BankManagementSystem.Server.NUnit.UnitTests.CommonData
{
    public abstract class BaseTestEntity
    {
        protected IWorkerService _workerService;
        protected ISQLRepository<Worker> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ISQLRepository<Worker>>();
            _workerService = new WorkerService(_repository);
        }
    }
}