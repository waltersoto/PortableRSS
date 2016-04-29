
using System;
using System.Linq;
using PortableRSS;

namespace RSSConsoleTest {
    class Program {
        static void Main() {

            string feed = "http://news.yahoo.com/rss/";

            var ch = Reader.Get(feed);

            Console.WriteLine(ch.Title);
            Console.WriteLine("=========================");
            Console.WriteLine();

            ch.Items.ToList().ForEach(x => {
                Console.WriteLine(" -> {0}", x.Title);
                if (!x.Content.Any()) return;
                foreach (var m in x.Content) {
                    Console.WriteLine(" -> -> {0} {1}", m.Type, m.Url);
                }
            });

            Console.ReadLine();

        }
    }
}
