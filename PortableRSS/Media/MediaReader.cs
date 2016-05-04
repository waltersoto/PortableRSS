using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PortableRSS.Media.Interfaces;

namespace PortableRSS.Media {
    public class MediaReader : IMediaReader {

        private ITag ReadTag(string tagString) {
            var parts = tagString.Split(':');
            var name = "";
            var weight = 0;

            if (parts.Length > 0) {
                name = parts[0];
            }

            if (parts.Length > 1) {
                int.TryParse(parts[1], out weight);
            }

            return new Tag {
                Name = name,
                Weight = weight
            };
        }

        private Media media;

        public IMedia Get(IEnumerable<XElement> element) {
            media = new Media();

            foreach (var i in element) {

                //Assign any non-content element
                AssignToMedia(i);

                if (i.Name.LocalName.Equals("content", StringComparison.OrdinalIgnoreCase)) {
                    #region "Content"
                    var content = new Content();
                    if (i.HasAttributes) {
                        foreach (var att in i.Attributes()) {
                            switch (att.Name.LocalName.ToLower()) {
                                case "url":
                                    content.Url = att.Value;
                                    break;
                                case "filesize":
                                    content.FileSize = att.Value;
                                    break;
                                case "type":
                                    content.Type = att.Value;
                                    break;
                                case "medium":
                                    content.Medium = att.Value;
                                    break;
                                case "isdefault":
                                    content.IsDefault = att.Value.Trim().ToLower() == "true";
                                    break;
                                case "expression":
                                    content.Expression = att.Value;
                                    break;
                                case "bitrate":
                                    content.BitRate = att.Value;
                                    break;
                                case "framerate":
                                    content.FrameRate = att.Value;
                                    break;
                                case "samplingrate":
                                    content.SamplingRate = att.Value;
                                    break;
                                case "channels":
                                    content.Channels = att.Value;
                                    break;
                                case "duration":
                                    content.Duration = att.Value;
                                    break;
                                case "height":
                                    content.Height = att.Value;
                                    break;
                                case "width":
                                    content.Width = att.Value;
                                    break;
                                case "lang":
                                    content.Lang = att.Value;
                                    break;
                            }
                        }

                    }

                    if (i.HasElements) {
                        foreach (var contentElem in i.Elements()) {
                            //Assign any element child of content
                            AssignToMedia(contentElem);
                        }
                    }

                    media.Content.Add(content);
                    #endregion
                }

            }

            return media;
        }

        private void AssignToMedia(XElement i) {
            if (media == null) {
                media = new Media();
            }

            switch (i.Name.LocalName.ToLower()) {
                case "text": {
                        #region "Text"
                        var text = new Text { Value = i.Value };
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "type":
                                        text.Type = att.Value;
                                        break;
                                    case "lang":
                                        text.Lang = att.Value;
                                        break;
                                    case "start":
                                        text.Start = att.Value;
                                        break;
                                    case "end":
                                        text.End = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Texts.Add(text);
                        #endregion
                    }
                    break;
                case "credit": {
                        #region "credit"
                        var credit = new Credit { Value = i.Value };
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "role":
                                        credit.Role = att.Value;
                                        break;
                                    case "scheme":
                                        credit.Scheme = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Credits.Add(credit);
                        #endregion
                    }
                    break;
                case "copyright": {
                        #region "copyright"
                        var copyright = new Copyright { Value = i.Value };
                        if (i.HasAttributes) {
                            var att =
                                i.Attributes()
                                    .FirstOrDefault(
                                        x => x.Name.LocalName.Equals("url", StringComparison.OrdinalIgnoreCase));
                            if (att != null) {
                                copyright.Url = att.Value;
                            }
                        }
                        media.Copyright = copyright;
                        #endregion
                    }
                    break;
                case "rating": {
                        #region "rating"

                        var rating = new Rating { Value = i.Value };
                        if (i.HasAttributes) {
                            var att =
                                i.Attributes()
                                    .FirstOrDefault(
                                        x => x.Name.LocalName.Equals("rating", StringComparison.OrdinalIgnoreCase));
                            if (att != null) {
                                rating.Value = att.Value;
                            }
                        }
                        media.Ratings.Add(rating);
                        #endregion
                    }
                    break;
                case "title": {
                        #region "title"

                        var title = new GenericContent { Value = i.Value };
                        if (i.HasAttributes) {
                            var att =
                                i.Attributes()
                                    .FirstOrDefault(
                                        x => x.Name.LocalName.Equals("type", StringComparison.OrdinalIgnoreCase));
                            if (att != null) {
                                title.Type = att.Value;
                            }
                        }
                        media.Title = title;

                        #endregion
                    }
                    break;
                case "description": {
                        #region "description"

                        var description = new GenericContent { Value = i.Value };
                        if (i.HasAttributes) {
                            var att =
                                i.Attributes()
                                    .FirstOrDefault(
                                        x => x.Name.LocalName.Equals("type", StringComparison.OrdinalIgnoreCase));
                            if (att != null) {
                                description.Type = att.Value;
                            }
                        }
                        media.Description = description;

                        #endregion
                    }
                    break;
                case "keywords": {
                        #region "keywords"

                        if (!string.IsNullOrEmpty(i.Value)) {
                            media.Keywords = i.Value.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();
                        }
                        #endregion
                    }
                    break;
                case "thumbnail":
                case "thumbnails": {
                        #region "thumbnails"
                        var thumbnail = new Thumbnail();
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "url":
                                        thumbnail.Url = att.Value;
                                        break;
                                    case "width":
                                        thumbnail.Width = att.Value;
                                        break;
                                    case "height":
                                        thumbnail.Height = att.Value;
                                        break;
                                    case "time":
                                        thumbnail.Time = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Thumbnails.Add(thumbnail);
                        #endregion
                    }
                    break;
                case "category": {
                        #region "category"
                        var category = new Category { Value = i.Value };
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "scheme":
                                        category.Scheme = att.Value;
                                        break;
                                    case "label":
                                        category.Label = att.Value;
                                        break;
                                }
                            }
                        }

                        #endregion
                    }
                    break;
                case "hash": {
                        #region "hash"
                        var hash = new Hash { Value = i.Value };
                        if (i.HasAttributes) {
                            var att =
                                i.Attributes()
                                    .FirstOrDefault(
                                        x => x.Name.LocalName.Equals("algo", StringComparison.OrdinalIgnoreCase));
                            if (att != null) {
                                hash.Algo = att.Value;
                            }
                        }
                        media.Hashes.Add(hash);
                        #endregion
                    }
                    break;
                case "player": {
                        #region "player"
                        var player = new Player();
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "url":
                                        player.Url = att.Value;
                                        break;
                                    case "height":
                                        player.Height = att.Value;
                                        break;
                                    case "width":
                                        player.Width = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Player = player;

                        #endregion
                    }
                    break;
                case "restriction": {
                        #region "restriction"
                        var restriction = new Restriction { Value = i.Value };

                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "relationship":
                                        restriction.Relationship = att.Value;
                                        break;
                                    case "type":
                                        restriction.Type = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Restrictions.Add(restriction);
                        #endregion
                    }
                    break;
                case "community": {
                        #region "community"
                        var community = new Community();

                        if (i.HasElements) {
                            foreach (var elem in i.Elements()) {
                                switch (elem.Name.LocalName.ToLower()) {
                                    case "starrating": {
                                            var starRating = new StartRating();
                                            if (elem.HasAttributes) {
                                                foreach (var att in elem.Attributes()) {
                                                    switch (att.Name.LocalName) {
                                                        case "average":
                                                            starRating.Average = att.Value;
                                                            break;
                                                        case "count":
                                                            starRating.Count = att.Value;
                                                            break;
                                                        case "min":
                                                            starRating.Min = att.Value;
                                                            break;
                                                        case "max":
                                                            starRating.Max = att.Value;
                                                            break;
                                                    }
                                                }
                                            }
                                            community.StartRating = starRating;
                                        }
                                        break;
                                    case "statistics": {
                                            var stats = new Statistics();
                                            if (elem.HasAttributes) {
                                                foreach (var att in elem.Attributes()) {
                                                    switch (att.Name.LocalName) {
                                                        case "views":
                                                            stats.Views = att.Value;
                                                            break;
                                                        case "favorites":
                                                            stats.Favorites = att.Value;
                                                            break;
                                                    }
                                                }
                                            }
                                            community.Statistics = stats;
                                        }
                                        break;
                                    case "tags":
                                        if (!string.IsNullOrEmpty(elem.Value)) {
                                            community.Tags = elem.Value.Split(',')
                                                .Where(x => !string.IsNullOrEmpty(x))
                                                .Select(ReadTag)
                                                .ToList();
                                        }
                                        break;
                                }
                            }
                        }

                        media.Community = community;

                        #endregion
                    }
                    break;
                case "comments": {
                        #region "comments"

                        if (i.HasElements) {
                            foreach (var elem in i.Elements()
                                .Where(elem => elem.Name.LocalName.Equals("comment", StringComparison.OrdinalIgnoreCase))
                                .Where(elem => !string.IsNullOrEmpty(elem.Value))) {
                                media.Comments.Add(elem.Value);
                            }
                        }

                        #endregion
                    }
                    break;
                case "embed": {
                        #region "embed"
                        var embed = new Embed();
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName) {
                                    case "url":
                                        embed.Url = att.Value;
                                        break;
                                    case "width":
                                        embed.Width = att.Value;
                                        break;
                                    case "height":
                                        embed.Height = att.Value;
                                        break;
                                }
                            }
                        }

                        if (i.HasElements) {
                            foreach (var elem in i.Elements().Where(x => x.Name.LocalName.Equals("param", StringComparison.OrdinalIgnoreCase))) {

                                var param = new Param {
                                    Value = elem.Value
                                };
                                if (elem.HasAttributes) {
                                    var att =
                                        elem.Attributes()
                                            .FirstOrDefault(
                                                x =>
                                                    x.Name.LocalName.Equals("name",
                                                        StringComparison.OrdinalIgnoreCase));
                                    if (att != null) {
                                        param.Name = att.Value;
                                    }
                                }
                                embed.Parameters.Add(param);
                            }
                        }
                        media.Embeds.Add(embed);
                        #endregion
                    }
                    break;
                case "responses": {
                        #region "responses"

                        if (i.HasElements) {
                            foreach (var elem in i.Elements()
                                                  .Where(x => x.Name.LocalName.Equals("response", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(x.Value))) {

                                media.Responses.Add(elem.Value);
                            }
                        }

                        #endregion
                    }
                    break;
                case "backlinks": {
                        #region "backLinks"
                        if (i.HasElements) {
                            foreach (var elem in i.Elements()
                                                  .Where(x => x.Name.LocalName.Equals("backLink", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(x.Value))) {

                                media.BackLinks.Add(elem.Value);
                            }
                        }

                        #endregion
                    }
                    break;
                case "rights": {
                        #region "backLinks"
                        if (i.HasAttributes) {
                            foreach (var att in i.Elements()
                                                  .Where(x => x.Name.LocalName.Equals("status", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(x.Value))) {

                                media.Rights.Add(att.Value);
                            }
                        }

                        #endregion
                    }
                    break;
                case "status": {
                        #region "status"
                        var status = new Status();
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "state":
                                        status.State = att.Value;
                                        break;
                                    case "reason":
                                        status.Reason = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Statuses.Add(status);
                        #endregion
                    }
                    break;
                case "price": {
                        #region "price"
                        var price = new Price();
                        if (i.HasAttributes) {

                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "type":
                                        price.Type = att.Value;
                                        break;
                                    case "info":
                                        price.Info = att.Value;
                                        break;
                                    case "price":
                                        price.PriceValue = att.Value;
                                        break;
                                    case "currency":
                                        price.Currency = att.Value;
                                        break;
                                }
                            }
                        }
                        media.Prices.Add(price);
                        #endregion
                    }
                    break;
                case "license": {
                        #region "license" 
                        var license = new License { Value = i.Value };
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "type":
                                        license.Type = att.Value;
                                        break;
                                    case "href":
                                        license.Href = att.Value;
                                        break;
                                }
                            }
                        }
                        media.License = license;

                        #endregion
                    }
                    break;
                case "subtitle": {
                        #region "subTitle"
                        var sub = new SubTitle();
                        if (i.HasAttributes) {

                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "type":
                                        sub.Type = att.Value;
                                        break;
                                    case "lang":
                                        sub.Lang = att.Value;
                                        break;
                                    case "href":
                                        sub.Href = att.Value;
                                        break;
                                }
                            }
                        }
                        media.SubTitles.Add(sub);
                        #endregion
                    }
                    break;
                case "peerlink": {
                        #region "peerLink"
                        var peer = new PeerLink();
                        if (i.HasAttributes) {
                            foreach (var att in i.Attributes()) {
                                switch (att.Name.LocalName.ToLower()) {
                                    case "type":
                                        peer.Type = att.Value;
                                        break;
                                    case "href":
                                        peer.Href = att.Value;
                                        break;
                                }
                            }
                        }
                        media.PeerLinks.Add(peer);
                        #endregion
                    }
                    break;
                case "scenes": {
                        #region "scenes"

                        if (i.HasElements) {
                            foreach (var elem in i.Elements().Where(x => x.Name.LocalName.Equals("scene", StringComparison.OrdinalIgnoreCase))) {
                                var scene = new Scene();

                                if (elem.HasElements) {
                                    foreach (var e in elem.Elements()) {
                                        switch (e.Name.LocalName.ToLower()) {
                                            case "scenetitle":
                                                scene.Title = e.Value;
                                                break;
                                            case "scenedescription":
                                                scene.Description = e.Value;
                                                break;
                                            case "scenestarttime":
                                                scene.StartTime = e.Value;
                                                break;
                                            case "sceneendtime":
                                                scene.EndTime = e.Value;
                                                break;
                                        }
                                    }
                                }
                                media.Scenes.Add(scene);
                            }
                        }

                        #endregion
                    }
                    break;
            }

        }

    }
}
