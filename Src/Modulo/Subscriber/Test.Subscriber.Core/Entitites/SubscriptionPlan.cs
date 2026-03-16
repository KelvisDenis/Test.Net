using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Subscriber.Core.Enums;

namespace Test.Subscriber.Core.Entitites
{
    public class SubscriptionPlan
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public decimal MonthlyPrice { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public PlanManagementEnum Status { get; private set; }
        public int DaysToExpire { get; private set; }

        public ICollection<Subscriber> Subscribers { get; private set; } = [];

        public SubscriptionPlan() { }

        public SubscriptionPlan(string name, decimal monthlyPrice, PlanManagementEnum status, ICollection<Subscriber> subscribers)
        {
            Id = Guid.NewGuid();
            Name = name;
            MonthlyPrice = monthlyPrice;
            Status = status;
            Subscribers = subscribers;
        }

    }
}
