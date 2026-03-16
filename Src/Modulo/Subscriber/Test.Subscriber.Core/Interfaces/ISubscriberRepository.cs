
namespace Test.Subscriber.Core.Interfaces
{
    public interface ISubscriberRepository
    {
        Task AddAsync(Entitites.Subscriber subscriber);

        Task<Entitites.Subscriber?> GetByIdAsync(Guid id);

        Task<Entitites.Subscriber?> GetByEmailAsync(string email);

        Task<List<Entitites.Subscriber>> GetAllActiveAsync();

        Task UpdateAsync(Entitites.Subscriber subscriber);

        Task DeleteAsync(Guid id);
    }
}
