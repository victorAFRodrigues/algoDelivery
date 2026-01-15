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

    public static Item BrandNew(string name, int quantity)
    {
        return new Item(name, quantity);
    }
    public void ChangeQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero");

        Quantity = quantity;
    }

}