namespace CarSalesmen
{
    public class MattPurchaseToken : IVehiclePurchaseToken
    {
        private readonly MattsTrustworthyQuote m_Quote;
        private readonly MattsMotors m_MattsMotors;

        public MattPurchaseToken(MattsMotors mattsMotors, MattsTrustworthyQuote quote)
        {
            m_Quote = quote;
            m_MattsMotors = mattsMotors;
        }

        public PriceInPounds Price => new PriceInPounds( m_Quote.Price * 0.1);

        public VehicleReceipt PurchaseVehicle()
        {
            return m_MattsMotors.BuyVehicle(m_Quote);
        }
    }
}