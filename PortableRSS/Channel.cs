﻿
using System;
using System.Collections.Generic;
using PortableRSS.Interfaces;

namespace PortableRSS {
    public class Channel : IChannel {
        public Channel() {
            Image = new Image();
            Items = new List<IItem>();
        }

        public string Title { set; get; }
        public string Link { set; get; }
        public string Description { set; get; }

        public string Language { set; get; }
        public string Copyright { set; get; }
        public string PubDate { set; get; }
        public string LastBuildDate { set; get; }
        public string Category { set; get; }
        public string Generator { set; get; }
        public string TTL { set; get; }
        public IImage Image { set; get; }
        public IList<IItem> Items { set; get; }

    }
}
