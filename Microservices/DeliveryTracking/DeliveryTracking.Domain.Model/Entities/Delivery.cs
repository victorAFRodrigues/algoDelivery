using DeliveryTracking.Domain.Model.Enums;

namespace DeliveryTracking.Domain.Model.Entities;

public class Delivery
{
    public Guid Id { get; private set; }
    public DeliveryStatus Status { get; private set; }
    public Guid CourierId { get; private set; }
    public DateTime PlacedAt { get; private set; }
    public DateTime AssignedAt { get; private set; }
    public DateTime ExpectedDeliveryAt { get; private set; }
    public DateTime FulfilledAt { get; private set; }
    public decimal DistanceFee { get; private set; }
    public decimal CourierPayout  { get; private set; }
    public decimal TotalCost { get; private set; }
    public int TotalItems { get; private set; }
    
    private Delivery(){}
    
    public Delivery(DeliveryStatus status,  Guid courierId, DateTime placedAt,  DateTime assignedAt, DateTime expectedDeliveryAt, DateTime fulfilledAt,decimal distanceFee, decimal courierPayout,  decimal totalCost, int totalItems)
    {
        Id = Guid.NewGuid();
        Status =  status;
        CourierId = courierId;
        PlacedAt = placedAt;
        AssignedAt = assignedAt;
        ExpectedDeliveryAt = expectedDeliveryAt;
        FulfilledAt = fulfilledAt;
        DistanceFee = distanceFee;
        CourierPayout = courierPayout;
        TotalCost = totalCost;
        TotalItems = totalItems;
        
    }

    public Guid AddItem(string name, int quantity)
    {
        return Guid.NewGuid();
    }
    public void RemoveItem(Guid itemId){}
    public void RemoveItems(){}
    public void EditPreparationDetails(string preparationDetails){}
    public void Place(){}
    public void PickUp(Guid courierId){}
    public void MarkAsDelivered(){}

    public Delivery Draft()
    {
        return new();
    }
    
}