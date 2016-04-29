
using PortableRSS.Interfaces;

namespace PortableRSS {
    public class Enclosure : IEnclosure {
        public string Url { set; get; }
        public string Length { set; get; }
        public string Type { set; get; }
    }
}
