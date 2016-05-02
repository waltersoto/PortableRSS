
using System.Collections.Generic;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class Media : IMedia {

        public Media() {
            Content = new List<IContent>();
            Ratings = new List<IRating>();
            Keywords = new List<string>();
            Thumbnails = new List<IThumbnail>();
            Categories = new List<ICategory>();
            Hashes = new List<IHash>();
            Credits = new List<ICredit>();
            Texts = new List<IText>();
            Restrictions = new List<IRestriction>();
            Comments = new List<string>();
            Embeds = new List<IEmbed>();
            Responses = new List<string>();
            BackLinks = new List<string>();
            Statuses = new List<IStatus>();
            Prices = new List<IPrice>();
            SubTitles = new List<ISubTitle>();
            PeerLinks = new List<IPeerLink>();
            Rights = new List<string>();
            Scenes = new List<IScene>();
        }

        public IList<IContent> Content { set; get; }
        public IList<IRating> Ratings { set; get; }
        public IGenericContent Title { set; get; }
        public IGenericContent Description { set; get; }
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
