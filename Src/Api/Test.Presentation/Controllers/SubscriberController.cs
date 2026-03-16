using Microsoft.AspNetCore.Mvc;
using Test.Subscriber.Application.Business;
using Test.Subscriber.Application.ValueObjects.Request;

namespace Test.Subscriber.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriberController(SubscriberBusiness _subscriberBusiness) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SubscriberCreated request)
    {
        var result = await _subscriberBusiness.AddSubscriber(request);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok("Assinante criado com sucesso.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActive()
    {
        var result = await _subscriberBusiness.GetAllActiveSubscriberAsync();

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _subscriberBusiness.GetById(id);

        if (result.IsFailure)
            return NotFound(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] SubscriberUpdate request)
    {
        var requestWithId = request with { Id = Guid.Parse(RouteData.Values["id"]?.ToString() ?? Guid.Empty.ToString()) };
        var result = await _subscriberBusiness.UpdateAsync(requestWithId);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok("Assinante atualizado com sucesso.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _subscriberBusiness.DeleteAsync(id);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok("Assinante removido com sucesso.");
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var result = await _subscriberBusiness.DeactivateSubscriptionAsync(id);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok("Assinatura desativada com sucesso.");
    }
}