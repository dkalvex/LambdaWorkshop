using MediatR;

namespace Shared.Events;

public class EventReceived : INotification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Source { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
