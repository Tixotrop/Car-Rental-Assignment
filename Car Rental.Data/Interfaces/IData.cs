using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    public List<T> Get<T>(Expression<Func<T, bool>>? expression);
    public T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);

    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    IBooking RentVehicle(int vehicleId, int customerId);
    IBooking ReturnVehicle(int vehicleId, double distance);

    public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));
    public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));

    public VehicleTypes GetVehicleType(string name)
    {
        Enum.TryParse(name, out VehicleTypes vehicleType);
        return vehicleType;
    }
}
