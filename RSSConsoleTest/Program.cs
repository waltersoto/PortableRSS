
using System;
using PortableRSS;

namespace RSSConsoleTest {
    class Program {
        static void Main() {

            const string Feed = "http://news.yahoo.com/rss/";

            Read(Feed);

            Console.ReadLine();

        }

        static void Process() {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(i.ToString());
            }
        }

        static async void Read(string url) {

            var ch = Reader.GetAsync(url);
            Process();
            var completed = await ch;
            Console.WriteLine("{0} ({1})", completed.Title, completed.Items.Count);

        }

    }
}
