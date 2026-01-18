namespace CourierManagement.Domain.Model.Entities;

public class Courier
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Phone  { get; private set; }
    public int FulFilledDeliveriesQuantity { get; private set; }
    public int PendingDeliveriesQuantity { get; private set; }
    public DateTimeOffset LastFulFilledDeliveryAt { get; private set; }

    private List<AssignedDelivery> _pendingDeliveries = new ();
    public IReadOnlyCollection<AssignedDelivery> PendingDeliveries => _pendingDeliveries.AsReadOnly();
    
    private Courier() { }

    public Courier(string name, string phone, int pendingDeliveriesQuantity, int fulFilledDeliveriesQuantity)
    {
        Id = Guid.NewGuid();
        Name = name;
        Phone = phone;
        PendingDeliveriesQuantity = pendingDeliveriesQuantity;
        FulFilledDeliveriesQuantity = fulFilledDeliveriesQuantity;
    }

    public void Assign(Guid deliveryId)
    {
        _pendingDeliveries.Add(AssignedDelivery.Pending(deliveryId));
        PendingDeliveriesQuantity++;
    }

    public void FulFill(Guid deliveryId)
    {
        var delivery = _pendingDeliveries.FirstOrDefault(x => x.Id == deliveryId);
        
        if (delivery == null)
            throw new Exception($"Delivery not found for id: {deliveryId}");
                
        _pendingDeliveries.Remove(delivery);
        LastFulFilledDeliveryAt = DateTimeOffset.UtcNow;
    }

    public static Courier BrandNew(string name, string phone)
    {
        return new(
            name,  
            phone,
            0,
            0
        );
    }
    
    
    
    
    
}