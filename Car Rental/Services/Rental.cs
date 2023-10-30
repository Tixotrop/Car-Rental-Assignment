using Car_Rental.Business.Classes;
using Car_Rental.Common.Classes;

namespace Car_Rental.Services;

public class Rental
{
    public Customer newCustomer = new();
    public int rentingCustomer = 0;
    public Vehicle newVehicle = new();
    public string error = string.Empty;
    public bool disableInput = false;
    public double kmDrived;

    BookingProcessor bp;
    public Rental(BookingProcessor bp)
    {
        this.bp = bp;
    }

    public void AddCustomer()
    {
        error = string.Empty;
        if (Valid(newCustomer.SSN) && Valid(newCustomer.FirstName) && Valid(newCustomer.LastName))
        {
            bp.AddCustomer(newCustomer);
            newCustomer = new();
        }
        else
        {
            error = "Could not add customer";
        }

    }

    public void AddVehicle()
    {
        error = string.Empty;
        if (Valid(newVehicle.Make) && Valid(newVehicle.RegNo))
        {
            bp.AddVehicle(newVehicle);
            newVehicle = new();
        }
        else
        {
            error = "Could not add vehicle";
        }
    }

    public async Task RentVehicle(int vehicleId)
    {
        error = string.Empty;
        if(rentingCustomer == 0)
        {
            error = "Please choose a customer";
            return;
        }
        disableInput = true;
        disableInput = !await bp.RentVehicle(vehicleId, rentingCustomer);
    }

    public void ReturnVehicle(int vehicleId)
    {
        error = string.Empty;
        bp.ReturnVehicle(vehicleId, kmDrived);
        kmDrived = 0;
    }

    private bool Valid(string str)
    {
        return !string.IsNullOrEmpty(str);
    }
}
