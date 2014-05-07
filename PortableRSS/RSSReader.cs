using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;

namespace PortableRSS
{
    public static class RSSReader
    {

        /// <summary>
        /// Parse RSS feed
        /// </summary>
        /// <param name="url">Feed url</param>
        /// <returns>RSSChannel</returns>
        public static RSSChannel Get(string url)
        {
            RSSChannel channel = new RSSChannel();

            try
            { 
                var ch = XElement.Load(url).Elements("channel");
                //Let's parse the channel information
                var chan = ch.Elements().Where(m => m.Name.LocalName.ToLower() != "item");

                foreach (var c in chan.Elements())
                {
                    switch (c.Name.LocalName.ToLower())
                    {
                        case "title": channel.Title = c.Value;
                            break;
                        case "link": channel.Link = c.Value;
                            break;
                        case "description": channel.Description = c.Value;
                            break;
                        case "language": channel.Language = c.Value;
                            break;
                        case "copyright": channel.Copyright = c.Value;
                            break;
                        case "pubdate": channel.PubDate = c.Value;
                            break;
                        case "ttl": 
                            channel.TTL = c.Value;
                            break;
                        case "image":
                            foreach (var chImg in c.Elements())
                            {
                                switch (chImg.Name.LocalName.ToLower())
                                {
                                    case "url": channel.Image.Url = chImg.Value;
                                        break;
                                    case "link": channel.Image.Link = chImg.Value;
                                        break;
                                    case "title": channel.Image.Title = chImg.Value;
                                        break;
                                }
                            }
                            break;
                    }
                }

                //Let's parse the items
                var items = ch.Elements().Where(m => m.Name.LocalName.ToLower() == "item");

                foreach (var item in items)
                {
                    RSSItem entry = new RSSItem();

                    foreach (var i in item.Elements())
                    {
                        switch (i.Name.LocalName.ToLower())
                        {
                            case "title": entry.Title = i.Value;
                                break;
                            case "description": entry.Description = i.Value;
                                break;
                            case "link": entry.Link = i.Value;
                                break;
                            case "pubdate": entry.PubDate = i.Value;
                                break;
                            case "guid": entry.Guid = i.Value;
                                break;
                            case "author": entry.Author = i.Value;
                                break;
                            case "comments": entry.Comments = i.Value;
                                break;
                            case "source": entry.Source = i.Value;
                                break;
                            case "category": entry.Category = i.Value;
                                break;
                            case "enclosure":
                                if (i.HasAttributes)
                                {
                                    RSSEnclosure en = new RSSEnclosure();
                                    if (i.Attribute("url") != null)
                                    {
                                        en.Url = i.Attribute("url").Value;
                                    }

                                    if (i.Attribute("length") != null)
                                    {
                                        en.Length = i.Attribute("length").Value;
                                    }

                                    if (i.Attribute("type") != null)
                                    {
                                        en.Type = i.Attribute("type").Value;
                                    }

                                    entry.Enclosure = en;
                                }
                                break;
                        }
                    }
                    channel.Items.Add(entry);
                } 

            }
            catch (XmlException ex)
            { 
            }


            return channel;
        }

    }
}
