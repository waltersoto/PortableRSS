
using System.Collections.Generic;
using PortableRSS.Media;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Interfaces {
    public interface IItem {
        string Title { set; get; }
        string Link { set; get; }
        string Description { set; get; }
        string Author { set; get; }
        string Category { set; get; }
        string Comments { set; get; }
        IEnclosure Enclosure { set; get; }
        IList<IContent> Content { set; get; }
        string PubDate { set; get; }
        string Guid { set; get; }
        string Source { set; get; }
    }
}
