

using System.Threading.Tasks;

namespace PortableRSS.Interfaces {
    public interface IReader {
        IChannel Get(string url);
        Task<IChannel> GetAsync(string url);
    }
}
