

using System.Collections.Generic;

namespace PortableRSS.Media.Interfaces {
    public interface IMedia {
        IList<IContent> Content { set; get; }
        IList<IRating> Ratings { set; get; }
        IGenericContent Title { set; get; }
        IGenericContent Description { set; get; }
        IList<string> Keywords { set; get; }
        IList<IThumbnail> Thumbnails { set; get; }
        IList<ICategory> Categories { set; get; }
        IList<IHash> Hashes { set; get; }
        IPlayer Player { set; get; }
        IList<ICredit> Credits { set; get; }
        ICopyright Copyright { set; get; }
        IList<IText> Texts { set; get; }
        IList<IRestriction> Restrictions { set; get; }
        ICommunity Community { set; get; }
        IList<string> Comments { set; get; }
        IList<IEmbed> Embeds { set; get; }
        IList<string> Responses { set; get; }
        IList<string> BackLinks { set; get; }
        IList<IStatus> Statuses { set; get; }
        IList<IPrice> Prices { set; get; }
        ILicense License { set; get; }
        IList<ISubTitle> SubTitles { set; get; }
        IList<IPeerLink> PeerLinks { set; get; }
        IList<string> Rights { set; get; }
        IList<IScene> Scenes { set; get; }
    }
}
