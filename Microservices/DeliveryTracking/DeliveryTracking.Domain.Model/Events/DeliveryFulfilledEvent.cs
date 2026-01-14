namespace DeliveryTracking.Domain.Model.Events;

public record DeliveryFulfilledEvent(Guid DeliveryId, DateTime OccurredAt);