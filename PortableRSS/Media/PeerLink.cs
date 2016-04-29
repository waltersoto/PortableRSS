

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class PeerLink : IPeerLink {
        public string Type { set; get; }
        public string Href { set; get; }
    }
}
