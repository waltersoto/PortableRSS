

using System.Collections.Generic;
using PortableRSS.Interfaces;
using PortableRSS.Media.Interfaces;

namespace PortableRSS {
    public class Item : IItem {
        public Item() {
            Enclosure = new Enclosure();
            Media = new Media.Media();
        }

        public string Title { set; get; }
        public string Link { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public string Category { set; get; }
        public string Comments { set; get; }
        public IEnclosure Enclosure { set; get; }
        public IMedia Media { set; get; }
        public string PubDate { set; get; }
        public string Guid { set; get; }
        public string Source { set; get; }

    }
}
