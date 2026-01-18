namespace CourierManagement.Domain.Model.Entities;

public class AssignedDelivery
{
    public Guid Id { get; private set; }
    public DateTimeOffset AssignedAt { get; private set; }
    
    private AssignedDelivery() { }

    public AssignedDelivery(Guid id, DateTimeOffset assignedAt)
    {
        Id = id;
        AssignedAt = assignedAt;
    }

    public static AssignedDelivery Pending(Guid deliveryId)
    {
        return new AssignedDelivery(deliveryId, DateTimeOffset.Now);
    }
}