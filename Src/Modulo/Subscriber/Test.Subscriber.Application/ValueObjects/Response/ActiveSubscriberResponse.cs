namespace Test.Subscriber.Application.ValueObjects.Response
{
    public record ActiveSubscriberResponse(
        Guid Id,
        string Name,
        string Email,
        string PlanName,
        DateTime SubscriptionStartDate
    );
}
