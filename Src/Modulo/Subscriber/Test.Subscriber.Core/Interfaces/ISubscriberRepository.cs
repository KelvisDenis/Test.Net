
using Test.Subscriber.Core.Entitites;

namespace Test.Subscriber.Core.Interfaces
{
    public interface ISubscriberRepository
    {
        Task AddAsync(Entitites.Subscriber subscriber);

        Task<Entitites.Subscriber?> GetByIdAsync(Guid id);
        Task<List<Entitites.Subscriber>> GetAllActiveAsync();
        Task<bool> IsEmailRegisteredAsync(string email);
        Task<SubscriptionPlan?> GetPlanByIdAsync(Guid planId);
        Task UpdateAsync(Entitites.Subscriber subscriber);

        Task DeleteAsync(Guid id);
    }
}
