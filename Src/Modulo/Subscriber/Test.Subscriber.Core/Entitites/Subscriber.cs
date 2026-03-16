using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Subscriber.Core.Enums;

namespace Test.Subscriber.Core.Entitites
{
    public class Subscriber
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public PlanManagementEnum Status { get; private set; }
        public SubscriptionPlan? SubscriptionPlan { get; private set; }
        public Guid SubscriptionPlanId { get; private set; }


        public Subscriber() { }
        public Subscriber( string name, string email, PlanManagementEnum status, Guid subscriptionPlanId)
        {

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Status = status;
            SubscriptionPlanId = subscriptionPlanId;
        }

    }
}
