using Microsoft.AspNetCore.TestHost;

namespace BankManagementSystem.Server.NUnit.IntegrationTests
{
    public abstract class BaseTestEntity
    {
        protected TestServer Server;

        public BaseTestEntity()
        {
            Server = new ServerApiFactory().Server;
        }
    }
}