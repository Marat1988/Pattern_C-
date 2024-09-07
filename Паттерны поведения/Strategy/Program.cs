namespace Strategy
{

    interface IReader
    {
        void Parse(string url);
    }

    class ResourceReader
    {
        private IReader reader;
        public ResourceReader(IReader reader) => this.reader = reader;
        public void SetStrategy(IReader reader) => this.reader = reader; 
        public void Read(string url) => reader.Parse(url);
    }

    class NewSiteReader : IReader
    {
        public void Parse(string url)
        {
            Console.WriteLine($"Парсинг с новостного сайта: {url}");
        }
    }

    class SocialNetworkReader : IReader
    {
        public void Parse(string url)
        {
            Console.WriteLine($"Парсинг ленты новостей социальной сети: {url}");
        }
    }

    class TelegramChannerReader : IReader
    {
        public void Parse(string url)
        {
            Console.WriteLine($"Парсинг канала месенджера Telegram: {url}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ResourceReader resourceReader = new ResourceReader(new NewSiteReader());
            string url = "http://news.com";
            resourceReader.Read(url);

            url = "https://facebook.com";
            resourceReader.SetStrategy(new  SocialNetworkReader());
            resourceReader.Read(url);

            url = "@news_channel_telegram";
            resourceReader.SetStrategy(new  TelegramChannerReader());
            resourceReader.Read(url);
        }
    }
}
