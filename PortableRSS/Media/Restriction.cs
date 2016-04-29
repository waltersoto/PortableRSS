
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Restriction : IRestriction {
        public string Relationship { set; get; }
        public string Type { set; get; }
        public string Value { set; get; }
    }
}
