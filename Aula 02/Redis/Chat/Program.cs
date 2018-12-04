using System;
using StackExchange.Redis;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {            
            var redis = ConnectionMultiplexer.Connect("13netredis.redis.cache.windows.net:6380,password=4QVvOK+dZhMK1s7as+qCJBWOHT2tbfmJYMoMc4dgfhA=,ssl=True,abortConnect=False");
            //var redis = ConnectionMultiplexer.Connect("trezenetredis.redis.cache.windows.net:6380,password=ftXkXFGfHf9Pf4sIJ8LVIgSQTAmU7I38nnRf96qmipE=,ssl=True,abortConnect=False");

            var db = redis.GetDatabase();

            var pubsub = redis.GetSubscriber();
            pubsub.Subscribe("13net", (channel, message) => Console.WriteLine(message.ToString()));

            Console.WriteLine("Digite o seu nome:");
            var nome = Console.ReadLine();

            db.Publish("13net", $"{nome} entrou na sala");

            while (true)
            {
                var msg = Console.ReadLine();
                db.Publish("13net", msg);
            }
        }
    }
}
