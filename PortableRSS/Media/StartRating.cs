
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class StartRating : IStartRating {
        public string Average { set; get; }
        public string Count { set; get; }
        public string Min { set; get; }
        public string Max { set; get; }
    }
}
