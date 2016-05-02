
using System.Collections.Generic;


namespace PortableRSS.Media.Interfaces {
    public interface IEmbed {
        string Url { set; get; }
        string Width { set; get; }
        string Height { set; get; }
        IList<IParam> Parameters { set; get; }
    }
}
