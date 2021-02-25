using CarSalesmen.ResultObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesmen
{
    public class JudsonsDealer : ICarDealer
    {
        private JudsonsJallopies m_Judsons;

        public JudsonsDealer(JudsonsJallopies judsons)
        {
            m_Judsons = judsons;
        }

        public VehicleReceipt BuyCar(IVehiclePurchaseToken vehiclePurchaseToken)
        {
            return vehiclePurchaseToken.PurchaseVehicle();
        }

        public Result<string, IVehiclePurchaseToken> GetPurchaseTokenForVehicleRequest(VehicleRequest vehicleRequest)
        {
            var quote = m_Judsons.GetQuote(vehicleRequest.RequestedModel, vehicleRequest.MaxAge);
            return quote != null ?
             Result.Ok<string, IVehiclePurchaseToken>(new JudsonsPurchaseToken(m_Judsons, quote)) :
             Result.Fail<string, IVehiclePurchaseToken>("Could not get the vehicle from here");
        }
    }
}
