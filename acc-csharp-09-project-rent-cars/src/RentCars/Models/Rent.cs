using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;
        Status = RentStatus.Confirmed;

        if (person is LegalPerson)
        {
            Price = vehicle.PricePerDay * daysRented * 0.9;
        }
        else
        {
            Price = vehicle.PricePerDay * daysRented;
        }

        vehicle.IsRented = true;
        person.Debit = Price;
    }

    public void Cancel()
    {        
        Status = RentStatus.Cancelled;
    }

    public void Finish()
    {        
        Status = RentStatus.Finished;
    }
}
