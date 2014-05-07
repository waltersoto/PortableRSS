using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortableRSS
{
    public class RSSChannel
    {
        public RSSChannel()
        {
            Image = new RSSImage();
            Items = new List<RSSItem>();
        }

        public string Title { set; get; }
        public string Link { set; get; }
        public string Description { set; get; }

        public string Language { set; get; }
        public string Copyright { set; get; } 
        public string PubDate { set; get; }
        public string LastBuildDate { set; get; }
        public string Category { set; get; }
        public string Generator { set; get; }
        public string TTL { set; get; }
        public RSSImage Image { set; get; }

        public List<RSSItem> Items { set; get; }

    }
}
