

using System.Collections.Generic;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {

    public class Community : ICommunity {

        public IStartRating StartRating { set; get; }
        public IStatistics Statistics { set; get; }
        public IList<ITag> Tags { set; get; }

    }
}
