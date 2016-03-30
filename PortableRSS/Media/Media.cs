
using System.Collections.Generic;

namespace PortableRSS.Media {
    public class Media {

        public IList<Content> Content { set; get; }
        public IList<Rating> Ratings { set; get; }
        public Title Title { set; get; }
        public Description Description { set; get; }
        public IList<string> Keywords { set; get; }
        public IList<Thumbnail> Thumbnails { set; get; }
        public IList<Category> Categories { set; get; }
        public IList<Hash> Hashes { set; get; }
        public Player Player { set; get; }
        public IList<Credit> Credits { set; get; }
        public Copyright Copyright { set; get; }
        public IList<Text> Texts { set; get; }
        public IList<Restriction> Restrictions { set; get; }
        public Community Community { set; get; }
        public IList<string> Comments { set; get; }
        public IList<Embed> Embeds { set; get; }
        public IList<string> Responses { set; get; }
        public IList<string> BackLinks { set; get; }
        public IList<Status> Statuses { set; get; }
        public IList<Price> Prices { set; get; }
        public License License { set; get; }
        public IList<SubTitle> SubTitles { set; get; }
        public IList<PeerLink> PeerLinks { set; get; }
        public IList<Rights> Rights { set; get; }
        public IList<Scene> Scenes { set; get; }

    }
}
