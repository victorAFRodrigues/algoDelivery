using DeliveryTracking.Domain.Model.Enums;
using DeliveryTracking.Domain.Model.ValueObjects;

namespace DeliveryTracking.Domain.Model.Entities;

public class Delivery
{
    public Guid Id { get; private set; }
    public DeliveryStatus Status { get; private set; }
    public Guid CourierId { get; private set; }
    public DateTimeOffset PlacedAt { get; private set; }
    public DateTimeOffset AssignedAt { get; private set; }
    public DateTimeOffset ExpectedDeliveryAt { get; private set; }
    public DateTimeOffset FulfilledAt { get; private set; }
    public decimal DistanceFee { get; private set; }
    public decimal CourierPayout  { get; private set; }
    public decimal TotalCost { get; private set; }
    public int TotalItems { get; private set; }
    
    public ContactPoint Sender { get; private set; }
    public ContactPoint Receiver { get; private set; }
    private readonly List<Item> _items = new();
    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();
    private Delivery(){}
    
    public Delivery( DeliveryStatus status, decimal distanceFee, decimal courierPayout,  decimal totalCost, int totalItems )
    {
        Id = Guid.NewGuid();
        Status =  status;
        DistanceFee = distanceFee;
        CourierPayout = courierPayout;
        TotalCost = totalCost;
        TotalItems = totalItems;
    }

    public void AddItem(string name, int quantity)
    {
        _items.Add(new Item(name, quantity));
        TotalItems = _items.Count;
    }
    public void RemoveItem(Guid itemId){}
    public void RemoveItems(){}
    public void EditPreparationDetails(string preparationDetails){}
    public void Place(){}
    public void PickUp(Guid courierId){}
    public void MarkAsDelivered(){}

    public static Delivery Draft()
    {
        return new (
            DeliveryStatus.Draft,
            0m,
            0m,
            0m,
            0
        );
    }
    
}