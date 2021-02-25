using CarSalesmen.ResultObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesmen
{
    public class JimmysDealer : ICarDealer
    {
        private readonly JimmysAutomobiles m_Jimmys;

        public JimmysDealer(JimmysAutomobiles jimmys)
        {
            m_Jimmys = jimmys;
        }

        public VehicleReceipt BuyVehicle(IVehiclePurchaseToken vehiclePurchaseToken)
        {
            return vehiclePurchaseToken.PurchaseVehicle();
        }

        public Result<string, IVehiclePurchaseToken> GetPurchaseTokenForVehicleRequest(VehicleRequest vehicleRequest)
        {
            try
            {
               var quote =  m_Jimmys.GetQuote(vehicleRequest.RequestedModel, TimeSpan.FromDays(60));
                if (quote.Age <= vehicleRequest.MaxAge)
                {
                    return Result.Ok<string, IVehiclePurchaseToken>(new JimmysPurchaseToken(m_Jimmys, quote));
                }
                else
                {
                    return Result.Fail<string, IVehiclePurchaseToken>("Ironically Jimmy's vehicle is too much of an old banger for us. Guess we're off to Matt's.");
                }
            }
            catch( Exception e){

                return Result.Fail<string, IVehiclePurchaseToken>(e.Message);
            }              
        }
    }
}
