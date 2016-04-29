

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Thumbnail : IThumbnail {
        public string Url { set; get; }
        public string Width { set; get; }
        public string Height { set; get; }
        public string Time { set; get; }
    }
}
