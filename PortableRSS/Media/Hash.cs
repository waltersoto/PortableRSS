

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Hash : IHash {
        public string Algo { set; get; }
        public string Value { set; get; }
    }
}
