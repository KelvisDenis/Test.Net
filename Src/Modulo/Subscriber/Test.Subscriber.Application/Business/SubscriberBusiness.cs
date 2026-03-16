using Test.Subscriber.Application.ValueObjects.Request;
using Test.Subscriber.Application.ValueObjects.Response;
using Test.Subscriber.Core.Helpers;
using Test.Subscriber.Core.Interfaces;

namespace Test.Subscriber.Application.Business
{
    public class SubscriberBusiness (ISubscriberRepository _subscriberRepository)
    {
        public async Task<Result> AddSubscriber(SubscriberCreated subscriber)
        {
            var plan = await _subscriberRepository.GetPlanByIdAsync(subscriber.PlanId);

            if (plan is null) 
                return Result.Failure("Plano não encontrado.");

            var existEmail = await _subscriberRepository.IsEmailRegisteredAsync(subscriber.Email);
            if (existEmail)
                return Result.Failure("Email já registrado.");

             var newSubscriber = new Core.Entitites.Subscriber(subscriber.Name, subscriber.Email, plan.Id);

            var result = newSubscriber.Validate();

            if (result.IsFailure)
                return Result.Failure(result.Error!);

            await _subscriberRepository.AddAsync(newSubscriber);

            return Result.Success();
        }

        public Task<Result<IList<ActiveSubscriberResponse>>> GetAllActiveSubscriberAsync()
        {
            throw new NotImplementedException();
        }
}
