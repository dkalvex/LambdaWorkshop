using MediatR;
using Shared.Events;
namespace LambdaWorkshop.SpeedProcessor.Handlers;
public class SpeedProcessorHandler : INotificationHandler<EventReceived>
{
    public Task Handle(EventReceived notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[SpeedProcessor] ⏱ Procesando evento rápido: {notification.Payload}");
        return Task.CompletedTask;
    }
}