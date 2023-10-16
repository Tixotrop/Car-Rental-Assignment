using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    public IEnumerable<IPerson> GetPersons();
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
    public IEnumerable<IBooking> GetBooking();

    
    List<T> Get<T>(Expression<Func<T, bool>>? expression);

    public void Add<T>(T item);
}
