
using System;
using System.Linq;
using PortableRSS;

namespace RSSConsoleTest {
    class Program {
        static void Main() {

            string feed = "http://news.yahoo.com/rss/";

            var ch = RSSReader.Get(feed);

            Console.WriteLine(ch.Title);
            Console.WriteLine("=========================");
            Console.WriteLine();
            ch.Items.ForEach(x => {
                Console.WriteLine(" -> {0}", x.Title);
                if (x.Content.Any()) {
                    foreach (var m in x.Content) {
                        Console.WriteLine(" -> -> {0} {1}", m.Type, m.Url);
                    }
                }
            });

            Console.ReadLine();

        }
    }
}
