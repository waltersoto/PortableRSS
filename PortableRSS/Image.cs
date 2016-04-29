using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortableRSS.Interfaces;

namespace PortableRSS {
    public class Image : IImage {
        public string Url { set; get; }
        public string Title { set; get; }
        public string Link { set; get; }
    }
}
