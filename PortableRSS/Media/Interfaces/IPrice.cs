

namespace PortableRSS.Media.Interfaces {
    public interface IPrice {
        string Type { set; get; }
        string PriceValue { set; get; }
        string Currency { set; get; }
        string Info { set; get; }
    }
}
