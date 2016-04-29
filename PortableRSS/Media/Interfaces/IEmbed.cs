
using System.Collections.Generic;


namespace PortableRSS.Media.Interfaces {
    public interface IEmbed {
        IList<IParam> Parameters { set; get; }
    }
}
