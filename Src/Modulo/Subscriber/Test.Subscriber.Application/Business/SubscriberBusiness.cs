using Mapster;
using Test.Subscriber.Application.ValueObjects.Request;
using Test.Subscriber.Application.ValueObjects.Response;
using Test.Subscriber.Core.Enums;
using Test.Subscriber.Core.Helpers;
using Test.Subscriber.Core.Interfaces;

namespace Test.Subscriber.Application.Business
{
    public class SubscriberBusiness(ISubscriberRepository _subscriberRepository)
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

        public async Task<Result<List<ActiveSubscriberResponse>>> GetAllActiveSubscriberAsync()
        {
            var all = await _subscriberRepository.GetAllActiveAsync();

            var mapped = all.Adapt<List<ActiveSubscriberResponse>>();

            return Result<List<ActiveSubscriberResponse>>.Success(mapped);
        }

        public async Task<Result<ActiveSubscriberResponse>> GetById(Guid id)
        {
            var subscriber = await _subscriberRepository.GetByIdAsync(id);

            if (subscriber is null)
                return Result<ActiveSubscriberResponse>.Failure("Assinante não encontrado.");

            var mapped = subscriber.Adapt<ActiveSubscriberResponse>();

            return Result<ActiveSubscriberResponse>.Success(mapped);
        }

        public async Task<Result> UpdateAsync(SubscriberUpdate request)
        {
            var subscriber = await _subscriberRepository.GetByIdAsync(request.Id);

            if (subscriber is null)
                return Result.Failure("Assinante não encontrado.");

            if (subscriber.Status != PlanManagementEnum.Active)
                return Result.Failure("Apenas assinantes ativos podem ser editados.");

            var plan = await _subscriberRepository.GetPlanByIdAsync(request.PlanId);

            if (plan is null)
                return Result.Failure("Plano não encontrado.");

            var existEmail = await _subscriberRepository.IsEmailRegisteredAsync(subscriber.Email);
            if (existEmail)
                return Result.Failure("Email já registrado.");

            subscriber.Update(request.Name, request.Email, request.PlanId);

            var result = subscriber.Validate();

            if (result.IsFailure)
                return Result.Failure(result.Error!);

            await _subscriberRepository.UpdateAsync(subscriber);


            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var subscriber = await _subscriberRepository.GetByIdAsync(id);

            if (subscriber is null)
                return Result.Failure("Assinante não encontrado.");

            if (subscriber.Status != PlanManagementEnum.Active)
                return Result.Failure("Apenas assinantes ativos podem ser editados.");

            await _subscriberRepository.DeleteAsync(id);

            return Result.Success();
        }

        public async Task<Result> DeactivateSubscriptionAsync(Guid id)
        {
            var subscriber = await _subscriberRepository.GetByIdAsync(id);
            if (subscriber is null)
                return Result.Failure("Assinante não encontrado.");

            if (subscriber.Status != PlanManagementEnum.Active)
                return Result.Failure("Apenas assinantes ativos podem ser editados.");

            subscriber.DeactivateSubscription();

            await _subscriberRepository.UpdateAsync(subscriber);

            return Result.Success();


        }
    }
}
