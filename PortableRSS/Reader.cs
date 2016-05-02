
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PortableRSS.Interfaces;
using PortableRSS.Media;
using System.Net.Http;
using PortableRSS.Media.Interfaces;

namespace PortableRSS {
    public class Reader : IReader {

        private IMediaReader mediaReader;

        public Reader() : this(new MediaReader()) { }

        public Reader(IMediaReader mediaReader) {
            this.mediaReader = mediaReader;
        }

        public async Task<IChannel> GetAsync(string url) {

            HttpResponseMessage httpResponse;

            using (var client = new HttpClient()) {
                httpResponse = await client.GetAsync(url);
            }
            var txt = "";
            if (httpResponse != null) {
                txt = await httpResponse.Content.ReadAsStringAsync();
            }
            var ch = XElement.Load(new StringReader(txt));
            return GetChannel(ch);
        }

        /// <summary>
        /// Parse RSS feed
        /// </summary>
        /// <param name="url">Feed url</param>
        /// <returns>RSSChannel</returns>
        public IChannel Get(string url) {
            var ch = XElement.Load(url);
            return GetChannel(ch);
        }


        private IChannel GetChannel(XContainer ch) {
            var channel = new Channel();

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
            var items = ch.Elements("channel").Elements().Where(m => m.Name.LocalName.ToLower() == "item");

            foreach (var item in items) {
                var entry = new Item();

                foreach (var i in item.Elements()) {
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

                #region "Get Media Elements"

                var mediaItems = item.Elements().Where(x => x.Name.IsMedia()).ToList();
                if (mediaItems.Any()) {
                    if (mediaReader != null) {
                        entry.Media = mediaReader.Get(mediaItems);
                    }
                }

                #endregion

                channel.Items.Add(entry);
            }


            return channel;
        }

    }
}
