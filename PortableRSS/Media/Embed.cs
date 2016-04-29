
using System.Collections.Generic;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Embed : IEmbed {
        public IList<IParam> Parameters { set; get; }
    }
}
