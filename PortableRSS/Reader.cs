
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using PortableRSS.Interfaces;
using PortableRSS.Media;

namespace PortableRSS {
    public static class Reader {

        private static bool IsMedia(XName name) {
            const string MediaNamespace = "http://search.yahoo.com/mrss/";
            return name.NamespaceName.Equals(MediaNamespace, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Parse RSS feed
        /// </summary>
        /// <param name="url">Feed url</param>
        /// <returns>RSSChannel</returns>
        public static IChannel Get(string url) {

            var channel = new Channel();

            var ch = XElement.Load(url).Elements("channel").FirstOrDefault();

            //Let's parse the channel information
            var chan = ch.Elements().FirstOrDefault(m => m.Name.LocalName.ToLower() != "item");

            #region "Channel Information"

            foreach (var c in chan.Elements()) {
                switch (c.Name.LocalName.ToLower()) {
                    case "title":
                        channel.Title = c.Value;
                        break;
                    case "link":
                        channel.Link = c.Value;
                        break;
                    case "description":
                        channel.Description = c.Value;
                        break;
                    case "language":
                        channel.Language = c.Value;
                        break;
                    case "copyright":
                        channel.Copyright = c.Value;
                        break;
                    case "pubdate":
                        channel.PubDate = c.Value;
                        break;
                    case "ttl":
                        channel.TTL = c.Value;
                        break;
                    case "image":
                        foreach (var chImg in c.Elements()) {
                            switch (chImg.Name.LocalName.ToLower()) {
                                case "url":
                                    channel.Image.Url = chImg.Value;
                                    break;
                                case "link":
                                    channel.Image.Link = chImg.Value;
                                    break;
                                case "title":
                                    channel.Image.Title = chImg.Value;
                                    break;
                            }
                        }
                        break;
                }
            }
            #endregion

            //Let's parse the items
            var items = ch.Elements().Where(m => m.Name.LocalName.ToLower() == "item");

            foreach (var item in items) {
                var entry = new Item();

                foreach (var i in item.Elements()) {
                    if (IsMedia(i.Name)) {
                        switch (i.Name.LocalName.ToLower()) {
                            case "content":
                                #region "Media Content"
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
                                entry.Content.Add(content);
                                #endregion
                                break;
                            case "":
                                break;
                        }
                    } else {

                        #region "RSS 2.0 items"

                        switch (i.Name.LocalName.ToLower()) {
                            case "title":
                                entry.Title = i.Value;
                                break;
                            case "description":
                                entry.Description = i.Value;
                                break;
                            case "link":
                                entry.Link = i.Value;
                                break;
                            case "pubdate":
                                entry.PubDate = i.Value;
                                break;
                            case "guid":
                                entry.Guid = i.Value;
                                break;
                            case "author":
                                entry.Author = i.Value;
                                break;
                            case "comments":
                                entry.Comments = i.Value;
                                break;
                            case "source":
                                entry.Source = i.Value;
                                break;
                            case "category":
                                entry.Category = i.Value;
                                break;
                            case "enclosure":
                                if (i.HasAttributes) {
                                    var en = new Enclosure();
                                    if (i.Attribute("url") != null) {
                                        en.Url = i.Attribute("url").Value;
                                    }

                                    if (i.Attribute("length") != null) {
                                        en.Length = i.Attribute("length").Value;
                                    }

                                    if (i.Attribute("type") != null) {
                                        en.Type = i.Attribute("type").Value;
                                    }

                                    entry.Enclosure = en;
                                }
                                break;
                        }

                        #endregion

                    }

                }
                channel.Items.Add(entry);
            }


            return channel;
        }

    }
}
