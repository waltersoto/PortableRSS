

using System.Collections.Generic;

namespace PortableRSS.Interfaces {
    public interface IChannel {

        string Title { set; get; }
        string Link { set; get; }
        string Description { set; get; }

        string Language { set; get; }
        string Copyright { set; get; }
        string PubDate { set; get; }
        string LastBuildDate { set; get; }
        string Category { set; get; }
        string Generator { set; get; }
        string TTL { set; get; }
        IImage Image { set; get; }
        IList<IItem> Items { set; get; }

    }
}
