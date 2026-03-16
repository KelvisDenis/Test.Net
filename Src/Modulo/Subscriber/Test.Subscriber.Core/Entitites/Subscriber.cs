using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Subscriber.Core.Enums;
using Test.Subscriber.Core.Helpers;

namespace Test.Subscriber.Core.Entitites
{
    public class Subscriber
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime SubscriptionStartDate { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public PlanManagementEnum Status { get; private set; }
        public SubscriptionPlan? SubscriptionPlan { get; private set; }
        public Guid SubscriptionPlanId { get; private set; }


        public Subscriber() { }
        public Subscriber(string name, string email, Guid subscriptionPlanId)
        {

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Status = PlanManagementEnum.Active;
            SubscriptionPlanId = subscriptionPlanId;
            SubscriptionStartDate = DateTime.UtcNow;
        }

        public Result<Subscriber> Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return Result<Subscriber>.Failure("Name is required.");

            if (string.IsNullOrWhiteSpace(Email))
                return Result<Subscriber>.Failure("Email is required.");

            if (!new EmailAddressAttribute().IsValid(Email))
                return Result<Subscriber>.Failure("Invalid email format.");

            if (SubscriptionStartDate > DateTime.UtcNow)
                return Result<Subscriber>.Failure("Start date cannot be greater than current date.");

            if (SubscriptionPlanId == Guid.Empty)
                return Result<Subscriber>.Failure("Subscription plan is required.");

            return Result<Subscriber>.Success(this);
        }

        public void Update(string name, string email, Guid planId)
        {
            Name = name;
            Email = email;
            SubscriptionPlanId = planId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeactivateSubscription()
        {
            Status = PlanManagementEnum.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
