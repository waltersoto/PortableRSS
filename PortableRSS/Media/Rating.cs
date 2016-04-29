
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Rating : IRating {
        public string Scheme { set; get; }
        public string Value { set; get; }
    }
}
