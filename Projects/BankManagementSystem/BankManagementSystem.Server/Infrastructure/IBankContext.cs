namespace BankManagementSystem.Server.Infrastructure
{
    public interface IBankContext
    {
        public IQueryable<T> GetEntities<T>() where T : class;
    }
}
