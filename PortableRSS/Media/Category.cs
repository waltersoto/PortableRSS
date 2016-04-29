
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Category : ICategory {

        public string Scheme { set; get; }
        public string Value { set; get; }

    }
}
