using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db)
    {
        _db = db;
    }
    public IEnumerable<Customer> GetCustomers()
    {
        return _db.GetPersons().Cast<Customer>().ToList();
    }

    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        return _db.GetVehicles(status);
    }            

    public IEnumerable<IBooking> GetBookings()
    {
        return _db.GetBooking();
    }    

    public void AddCustomer(Customer customer)
    {
        _db.Add<Customer>(customer);
    }
}
