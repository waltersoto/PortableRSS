
using System.Collections.Generic;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Embed : IEmbed {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public IList<IParam> Parameters { set; get; }
    }
}
