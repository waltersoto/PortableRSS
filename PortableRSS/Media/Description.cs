

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Description : IDescription {
        public string Type { set; get; }
        public string Value { set; get; }
    }
}
