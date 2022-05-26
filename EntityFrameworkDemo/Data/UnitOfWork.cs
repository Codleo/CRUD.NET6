namespace EntityFrameworkDemo.Data
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _apiDbContext;
        public UnitOfWork(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _apiDbContext.SaveChangesAsync();
        }
    }
}
