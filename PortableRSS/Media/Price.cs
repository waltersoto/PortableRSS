

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Price : IPrice {
        public string Type { set; get; }
        public string PriceValue { set; get; }
        public string Currency { set; get; }
        public string Info { set; get; }
    }
}
