namespace DeliveryTracking.Domain.Model.ValueObjects;

public record PreparationDetails(ContactPoint?  Sender, ContactPoint? Recipient, decimal DistanceFee, decimal CourierPayout, TimeSpan ExpectedDeliveryTime);
