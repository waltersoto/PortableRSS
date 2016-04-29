
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Status : IStatus {
        public string State { set; get; }
        public string Reason { set; get; }
    }
}
