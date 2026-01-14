namespace DeliveryTracking.Domain.Model.ValueObjects;

public record ContactPoint(
    string ZipCode,
    string Street,
    string Number,
    string Complement,
    string Name,
    string Phone
);