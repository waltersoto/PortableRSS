

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Credit : ICredit {
        public string Role { set; get; }
        public string Scheme { set; get; }
        public string Value { set; get; }
    }
}
