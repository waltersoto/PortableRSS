
using System.Collections.Generic;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Media : IMedia {

        public IList<IContent> Content { set; get; }
        public IList<IRating> Ratings { set; get; }
        public ITitle Title { set; get; }
        public IDescription Description { set; get; }
        public IList<string> Keywords { set; get; }
        public IList<IThumbnail> Thumbnails { set; get; }
        public IList<ICategory> Categories { set; get; }
        public IList<IHash> Hashes { set; get; }
        public IPlayer Player { set; get; }
        public IList<ICredit> Credits { set; get; }
        public ICopyright Copyright { set; get; }
        public IList<IText> Texts { set; get; }
        public IList<IRestriction> Restrictions { set; get; }
        public ICommunity Community { set; get; }
        public IList<string> Comments { set; get; }
        public IList<IEmbed> Embeds { set; get; }
        public IList<string> Responses { set; get; }
        public IList<string> BackLinks { set; get; }
        public IList<IStatus> Statuses { set; get; }
        public IList<IPrice> Prices { set; get; }
        public ILicense License { set; get; }
        public IList<ISubTitle> SubTitles { set; get; }
        public IList<IPeerLink> PeerLinks { set; get; }
        public IList<string> Rights { set; get; }
        public IList<IScene> Scenes { set; get; }

    }
}
