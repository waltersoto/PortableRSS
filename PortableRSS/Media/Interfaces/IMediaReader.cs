

using System.Collections.Generic;
using System.Xml.Linq;

namespace PortableRSS.Media.Interfaces {
    public interface IMediaReader {
        IMedia Get(IEnumerable<XElement> element);
    }
}
