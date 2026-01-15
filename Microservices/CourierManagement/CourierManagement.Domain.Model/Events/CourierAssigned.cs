namespace CourierManagement.Domain.Model.Events;

public record CourierAssigned(
    DateTime AssignedAt,
    Guid CourierId,
    Guid DeliveryId
);