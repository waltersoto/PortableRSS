
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Text : IText {
        public string Type { set; get; }
        public string Lang { set; get; }
        public string Start { set; get; }
        public string End { set; get; }
        public string Value { set; get; }
    }
}
