

using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Scene : IScene {
        public string Title { set; get; }
        public string Description { set; get; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
    }
}
