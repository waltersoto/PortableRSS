using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortableRSS.Tests {
    [TestClass]
    public class FeedParsing {
        [TestMethod]
        public void RequestChannelTest() {
            const string url = "http://rss.tvguide.com/breakingnews";
            var r = new Reader();
            var ch = r.Get(url);

            Assert.AreNotEqual(ch, null);
            Assert.AreNotEqual(0, ch.Items.Count);

        }
    }
}
