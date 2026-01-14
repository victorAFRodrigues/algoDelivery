namespace DeliveryTracking.Domain.Model.ValueObjects;

public struct ZipCode
{
    int ZipCodeNumber { get; }

    public ZipCode(int zipCodeNumber)
    {
        ZipCodeNumber = zipCodeNumber;
    }
}