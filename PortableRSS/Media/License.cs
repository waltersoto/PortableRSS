

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class License : ILicense {
        public string Type { set; get; }
        public string Href { set; get; }
        public string Value { set; get; }
    }
}
