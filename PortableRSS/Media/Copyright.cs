

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Copyright : ICopyright {
        public string Url { set; get; }
        public string Value { set; get; }
    }
}
