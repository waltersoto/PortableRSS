

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Title : ITitle {
        public string Type { set; get; }
        public string Value { set; get; }
    }
}
