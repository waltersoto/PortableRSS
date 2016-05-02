

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class GenericContent : IGenericContent {
        public string Type { set; get; }
        public string Value { set; get; }
    }
}
