namespace DeliveryTracking.Domain.Model.Entities;

public class Item
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    
    private Item(){}

    public Item(string name, int quantity)
    {
        Id = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
    }
}