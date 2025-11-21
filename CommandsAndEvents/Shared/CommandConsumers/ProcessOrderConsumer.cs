using MassTransit;
using Shared.Commands;
using Shared.Events;

namespace Shared.CommandConsumers;

public class ProcessOrderConsumer : IConsumer<ProcessOrder>
{
    public async Task Consume(ConsumeContext<ProcessOrder> context)
    {
        Console.WriteLine($"Inside ProcessOrder Command Consumer: Consuming the Command. OrderId: {context.Message.OrderId}");

        var orderedProcessed = new OrderProcessed
        {
            OrderId = context.Message.OrderId,
        };

        await context.Publish(orderedProcessed);
    }
}
