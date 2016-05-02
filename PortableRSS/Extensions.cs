

using System;
using System.Xml.Linq;

namespace PortableRSS {
    internal static class Extensions {
        public static bool IsMedia(this XName name) {
            const string MediaNamespace = "http://search.yahoo.com/mrss/";
            return name.NamespaceName.Equals(MediaNamespace, StringComparison.OrdinalIgnoreCase);
        }
    }
}
