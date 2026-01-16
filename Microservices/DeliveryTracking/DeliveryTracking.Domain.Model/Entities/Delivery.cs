using DeliveryTracking.Domain.Model.Enums;
using DeliveryTracking.Domain.Model.Exceptions;
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
    public ContactPoint Recipient { get; private set; }
    private readonly List<Item> _items = new();
    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();
    private Delivery(){}
    
    public Delivery( DeliveryStatus status, decimal distanceFee, decimal courierPayout,  decimal totalCost)
    {
        Id = Guid.NewGuid();
        Status =  status;
        DistanceFee = distanceFee;
        CourierPayout = courierPayout;
        TotalCost = totalCost;
        TotalItems = _items.Count;
    }

    public Guid AddItem(string name, int quantity)
    {
        Item item = Item.BrandNew(name, quantity);
        return item.Id;
    }
    public void RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null) throw new InvalidOperationException("Item not found");
        _items.Remove(item);
        TotalItems = _items.Count;
    }
    public void RemoveItems()
    {
        _items.ForEach(item => RemoveItem(item.Id));
        TotalItems = _items.Count;
    }
    public void ChangeItemQuantity(Guid itemId, int quantity)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null) throw new InvalidOperationException("Item not found");
        item.ChangeQuantity(quantity);
    }
    public void Place()
    {
        Status = DeliveryStatus.WaitingForCourier;
        PlacedAt = DateTimeOffset.Now;
    }
    public void EditPreparationDetails(
        PreparationDetails details,
        DateTimeOffset now
    )
    {
        VerifyIfCanBeEdited();

        Sender = details.Sender;
        Recipient = details.Recipient;
        DistanceFee = details.DistanceFee;
        CourierPayout = details.CourierPayout;
<<<<<<< HEAD
        ExpectedDeliveryAt = DateTimeOffset.UtcNow.Add(details.ExpectedDeliveryTime); 
        TotalCost = DistanceFee + details.CourierPayout;
=======

        ExpectedDeliveryAt = now + details.ExpectedDeliveryTime;
        TotalCost = DistanceFee + CourierPayout;
>>>>>>> c1411e787a5580ebb4ce444e3d23fe7205180d2a
    }
    public void PickUp(Guid courierId)
    {
        CourierId = courierId;
        Status = DeliveryStatus.InTransit;
        AssignedAt = DateTimeOffset.Now;
    }

    public void MarkAsDelivered()
    {
        Status = DeliveryStatus.Delivered;
        FulfilledAt = DateTimeOffset.Now;
    }

    public static Delivery Draft()
    {
        return new (
            DeliveryStatus.Draft,
            0m,
            0m,
            0m
        );
    }

    public class PreparationDetails
    {
        public ContactPoint Sender { get; private set; }
        public ContactPoint Recipient { get; private set; }
        public decimal DistanceFee { get; private set; }
        public decimal CourierPayout { get; private set; }
        public TimeSpan ExpectedDeliveryTime { get; private set; }
        
    }
    
    private void VerifyIfCanBePlaced() {
        if (!IsFilled()) {
            throw new DomainException();
        }
        if (!Status.Equals(DeliveryStatus.Draft)) {
            throw new DomainException();
        }
    }

    private void VerifyIfCanBeEdited() {
        if (!Status.Equals(DeliveryStatus.Draft)) {
            throw new DomainException();
        }
    }

    private bool IsFilled() {
        return Sender && Recipient && TotalCost > 0;
    }
    
}