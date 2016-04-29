
namespace PortableRSS.Interfaces {
    public interface IEnclosure {
        string Url { set; get; }
        string Length { set; get; }
        string Type { set; get; }
    }
}
