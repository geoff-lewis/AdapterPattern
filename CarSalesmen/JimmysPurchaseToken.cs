using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesmen
{
    public class JimmysPurchaseToken : IVehiclePurchaseToken
    {
        private readonly JimmysAutomobiles m_Jimmys;

        public JimmyDeal m_Quote { get; }

        public JimmysPurchaseToken(JimmysAutomobiles jimmys, JimmyDeal quote)
        {
            m_Jimmys = jimmys;
            m_Quote = quote;
        }

        public PriceInPounds Price => m_Quote.Price;

        public VehicleReceipt PurchaseVehicle()
        {
            return m_Jimmys.BuyVehicle(m_Quote);
        }
    }
}
