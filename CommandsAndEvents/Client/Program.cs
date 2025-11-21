using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Commands;


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

var host = builder.Build();

var applicationLifetimeService = host.Services.GetService<IHostApplicationLifetime>();
applicationLifetimeService?.ApplicationStarted.Register(async void (_, _) =>
{
    var bus = host.Services.GetService<IBus>();

    var processOrderMessage = new ProcessOrder { OrderId = "1" };

    if (bus is not null)
    {

        //awaiting some time so that the bus of the ApplicationA and ApplicationB is started already so that the ReceiveEndpoints are created before message is published(for the first time). Else the message will be lost. 
        await Task.Delay(5000);

        await bus.Publish(processOrderMessage);
        Console.WriteLine("ProcessOrder Message is published");
    }
}, null);

host.Run();