using MassTransit;
using Shared.CommandConsumers;
using Shared.Events;

namespace Shared.EventConsumers;

public class OrderProcessedConsumer : IConsumer<OrderProcessed>
{
    public Task Consume(ConsumeContext<OrderProcessed> context)
    {
        Console.WriteLine($"Inside OrderProcessedConsumer: Order {context.Message.OrderId} is Processed.");
        return Task.CompletedTask;
    }
}