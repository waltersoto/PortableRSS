

using System.Collections.Generic;

namespace PortableRSS.Media.Interfaces {
    public interface ICommunity {

        IStartRating StartRating { set; get; }
        IStatistics Statistics { set; get; }
        IList<ITag> Tags { set; get; }

    }
}
