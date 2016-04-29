

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Player : IPlayer {
        public string Url { set; get; }
        public string Height { set; get; }
        public string Width { set; get; }
    }
}
