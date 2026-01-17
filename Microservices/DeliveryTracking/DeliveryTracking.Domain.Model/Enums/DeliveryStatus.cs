namespace DeliveryTracking.Domain.Model.Enums;

public enum DeliveryStatus
{
    Draft,
    WaitingForCourier,
    InTransit,
    Delivered
}

public static class DeliveryStatusExtensions
{
    private static readonly Dictionary<DeliveryStatus, DeliveryStatus[]> AllowedPreviousStatuses = new()
    {
        { DeliveryStatus.Draft, Array.Empty<DeliveryStatus>() },
        { DeliveryStatus.WaitingForCourier, new[] { DeliveryStatus.Draft } },
        { DeliveryStatus.InTransit, new[] { DeliveryStatus.WaitingForCourier } },
        { DeliveryStatus.Delivered, new[] { DeliveryStatus.InTransit } },
    };

    private static bool CanChangeTo(this DeliveryStatus currentStatus, DeliveryStatus newStatus) => 
        AllowedPreviousStatuses.TryGetValue(newStatus, out var previousStatuses) && previousStatuses.Contains(currentStatus);

    public static bool CanNotChangeTo(this DeliveryStatus currentStatus, DeliveryStatus newStatus) 
        => !currentStatus.CanChangeTo(newStatus);
}
