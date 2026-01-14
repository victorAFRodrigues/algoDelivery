namespace DeliveryTracking.Domain.Model.Events;

public record DeliveryPlacedEvent(Guid DeliveryId, DateTime OccurredAt);