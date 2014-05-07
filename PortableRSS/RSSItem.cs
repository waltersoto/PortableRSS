using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortableRSS
{
    public class RSSItem
    {
        public RSSItem()
        {
            Enclosure = new RSSEnclosure();
        }

        public string Title { set; get; }
        public string Link { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public string Category { set; get; }
        public string Comments { set; get; }
        public RSSEnclosure Enclosure { set; get; }
        public string PubDate{ set; get; }
        public string Guid { set; get; }
        public string Source { set; get; }

    }
}
