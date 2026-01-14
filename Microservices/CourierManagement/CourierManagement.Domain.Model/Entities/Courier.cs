namespace CourierManagement.Domain.Model.Entities;

public class Courier
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Phone  { get; private set; }
    public int FulFilledDeliveriesQuantity { get; private set; }
    public int PendingDeliveriesQuantity { get; private set; }
    public DateTime LastFulFilledDeliveryAt { get; private set; }

    private Courier() { }

    public Courier(string name, string phone, int fulFilledDeliveriesQuantity, int pendingDeliveriesQuantity)
    {
        Id = Guid.NewGuid();
        Name = name;
        Phone = phone;
        FulFilledDeliveriesQuantity = fulFilledDeliveriesQuantity;
        PendingDeliveriesQuantity = pendingDeliveriesQuantity;
        LastFulFilledDeliveryAt = DateTime.Now;
    }
    
    public void Assign(Guid deliveryId) {}
    
    public void FulFill(Guid deliveryId) {}

    public Courier BrandNew(string name, string phone)
    {
        return new();
    }
    
    
    
    
    
}