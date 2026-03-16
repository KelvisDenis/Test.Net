using Microsoft.EntityFrameworkCore;
using Test.Subscriber.Core.Entitites;
using Test.Subscriber.Core.Enums;
using Test.Subscriber.Core.Interfaces;

namespace Test.Subscriber.Infraestructure.Database.Repositories
{
    public class SubscriberRepository (SubscriberDbContext _context) : ISubscriberRepository
    {
        public async Task AddAsync(Core.Entitites.Subscriber subscriber)
        {
            await _context.Subscribers.AddAsync(subscriber);

            await _context.SaveChangesAsync();
        }

        public async Task<Core.Entitites.Subscriber?> GetByIdAsync(Guid id)
        {
            return await _context.Subscribers
                .Include(x => x.SubscriptionPlan)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == PlanManagementEnum.Active);
        }

        public async Task<List<Core.Entitites.Subscriber>> GetAllActiveAsync()
        {
            return await _context.Subscribers
                .Include(x => x.SubscriptionPlan)
                .Where(x => x.Status == PlanManagementEnum.Active)
                .ToListAsync();
        }

        public async Task UpdateAsync(Core.Entitites.Subscriber subscriber)
        {
            _context.Subscribers.Update(subscriber);
            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteAsync(Guid id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);

            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _context.Subscribers.AsNoTracking().AnyAsync(x => x.Email == email);
        }

        public async Task<SubscriptionPlan?> GetPlanByIdAsync(Guid planId)
        {
            return await _context.SubscriptionPlans
                 .Where(x => x.Id == planId)
                 .FirstOrDefaultAsync();
        }
    }
}
