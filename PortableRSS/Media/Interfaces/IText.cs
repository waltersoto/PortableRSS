
namespace PortableRSS.Media.Interfaces {
    public interface IText {
        string Type { set; get; }
        string Lang { set; get; }
        string Start { set; get; }
        string End { set; get; }
        string Value { set; get; }
    }
}
