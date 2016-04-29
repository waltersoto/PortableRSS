
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Tag : ITag {
        public string Name { set; get; }
        public int Weight { set; get; }
    }
}
