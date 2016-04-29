
namespace PortableRSS.Media.Interfaces {

    public interface IContent {
        string Url { set; get; }
        string FileSize { set; get; }
        string Type { set; get; }
        string Medium { set; get; }
        bool IsDefault { set; get; }
        string Expression { set; get; }
        string BitRate { set; get; }
        string FrameRate { set; get; }
        string SamplingRate { set; get; }
        string Channels { set; get; }
        string Duration { set; get; }
        string Height { set; get; }
        string Width { set; get; }
        string Lang { set; get; }
    }

}
