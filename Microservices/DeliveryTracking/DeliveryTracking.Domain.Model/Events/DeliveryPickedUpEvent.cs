namespace DeliveryTracking.Domain.Model.Events;

public record DeliveryPickedUpEvent(Guid DeliveryId, DateTime OccurredAt);