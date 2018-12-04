using System;
using StackExchange.Redis;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisProprio = ConnectionMultiplexer.Connect("13netredis.redis.cache.windows.net:6380,password=4QVvOK+dZhMK1s7as+qCJBWOHT2tbfmJYMoMc4dgfhA=,ssl=True,abortConnect=False");
            var redis = ConnectionMultiplexer.Connect("trezenetredis.redis.cache.windows.net:6380,password=ftXkXFGfHf9Pf4sIJ8LVIgSQTAmU7I38nnRf96qmipE=,ssl=True,abortConnect=False");

            var db = redis.GetDatabase();
            var dbProprio = redisProprio.GetDatabase();

            Console.WriteLine("Digite seu RM:");
            var rm = Console.ReadLine();

            Console.WriteLine("Digite o seu nome:");
            var nome = Console.ReadLine();

            db.StringSet(rm, nome);
            dbProprio.StringSet(rm, nome);

            Console.WriteLine($"chave: {rm}, valor: {db.StringGet(rm)}");
            Console.Read();
        }
    }
}
