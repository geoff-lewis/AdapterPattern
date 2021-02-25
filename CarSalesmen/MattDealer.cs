using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSalesmen.ResultObject;

namespace CarSalesmen
{
    public class MattDealer : ICarDealer
    {
        private readonly MattsMotors m_MattsMotors;

        public MattDealer(MattsMotors mattsMotors)
        {
            m_MattsMotors = mattsMotors;
            m_MattsMotors.Initialise();
        }

        public VehicleReceipt BuyCar(IVehiclePurchaseToken vehiclePurchaseToken)
        {
            return vehiclePurchaseToken.PurchaseVehicle();
        }

        public Result<string, IVehiclePurchaseToken> GetPurchaseTokenForVehicleRequest(VehicleRequest vehicleRequest)
        {
            var quote = m_MattsMotors.GetPrice(vehicleRequest.RequestedModel, vehicleRequest.MaxAge.TotalHours);
            return quote.Price >= 0 ?
             Result.Ok<string, IVehiclePurchaseToken>(new MattPurchaseToken(m_MattsMotors, quote)) :
                Result.Fail<string, IVehiclePurchaseToken>("Matt doesn't seel this car. Go away.");
        }
    }
}
