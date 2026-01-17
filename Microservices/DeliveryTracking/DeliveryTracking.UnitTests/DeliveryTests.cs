using DeliveryTracking.Domain.Model.Entities;
using DeliveryTracking.Domain.Model.Enums;
using DeliveryTracking.Domain.Model.Exceptions;
using DeliveryTracking.Domain.Model.ValueObjects;

namespace DeliveryTracking.UnitTests;

public class DeliveryTests
{
    private PreparationDetails CreateValidPreparationDetails()
    {
        return new PreparationDetails(
            new ContactPoint("49095-140", "Rua Francisco de Paula Silva", "768", "casa branca", "Flávia Letícia Fernandes", "(85) 99564-6753"),
            new ContactPoint("26299-093", "Rua das Flores", "692", "casa verde", "Bianca Milena Louise Corte Real", "(21) 99710-5869"),
            15m,
            5m,
            new TimeSpan(5, 0, 0)
        );
    }
    
    [Test]
    public void ShouldChangeStatusToPlaced()
    {
        var delivery = Delivery.Draft();
        delivery.EditPreparationDetails(CreateValidPreparationDetails());
        delivery.Place();
        Assert.That(delivery.Status, Is.EqualTo(DeliveryStatus.WaitingForCourier));

    }
    
    [Test]
    public void ShouldNotChangeToInvalidProcess()
    {   
        var validCourierId = Guid.NewGuid();
        var delivery = Delivery.Draft();
        delivery.EditPreparationDetails(CreateValidPreparationDetails());
        
        Assert.Throws(typeof(DomainException), () => delivery.PickUp(validCourierId));
    }
    
}