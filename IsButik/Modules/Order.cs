namespace IsButik
{
    public class Order
    {
        public string container { get; set; }
        public string iceType { get; set; }
        public string scoops { get; set; }
        public string flavours { get; set; }
        public string sprinkles { get; set; }

        public string fullName { get; set; }
        public string cardType { get; set; } 
        public string cardNumber { get; set; }
        public string exp_Month { get; set; }
        public string exp_Year { get; set; }
        public string CVC { get; set; }
    }
}
