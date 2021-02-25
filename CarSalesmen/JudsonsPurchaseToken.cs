using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesmen
{
    public class JudsonsPurchaseToken : IVehiclePurchaseToken
    {
        private readonly JudsonsJallopies m_Judsons;
        private JudsonsUnbeatableQuote m_Quote;

        public JudsonsPurchaseToken(JudsonsJallopies Judsons, JudsonsUnbeatableQuote quote)
        {
            m_Judsons = Judsons;
            m_Quote = quote;
        }

        public PriceInPounds Price => m_Quote.Price;

        public VehicleReceipt PurchaseVehicle()
        {
            return m_Judsons.BuyVehicle(m_Quote);
        }


    }
}
