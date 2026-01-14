namespace CourierManagement.Domain.Model.Entities;

public class AssignedDelivery
{
    public Guid Id { get; private set; }
    public DateTime AssignedAt { get; private set; }
    
    private AssignedDelivery() { }

    public AssignedDelivery(Guid id, DateTime assignedAt)
    {
        Id = id;
        AssignedAt = assignedAt;
    }
}