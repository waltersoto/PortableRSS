
namespace PortableRSS.Media.Interfaces {
    public interface IRestriction {
        string Relationship { set; get; }
        string Type { set; get; }
        string Value { set; get; }
    }
}
