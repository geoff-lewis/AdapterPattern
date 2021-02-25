using CarSalesmen.ResultObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesmen
{
    public interface ICarDealer
    {
        Result<string,IVehiclePurchaseToken> GetPurchaseTokenForVehicleRequest(VehicleRequest vehicleRequest);

        VehicleReceipt BuyCar(IVehiclePurchaseToken vehiclePurchaseToken);
    }
}
