using System;
using Newtonsoft.Json;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain crimCoin = new Blockchain();
            crimCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Frankie,receiver:Ushan,amount:8}"));
            crimCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Ushan,receiver:Frankie,amount:4}"));
            crimCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Ushan,receiver:Frankie,amount:10}"));

            Console.WriteLine(JsonConvert.SerializeObject(crimCoin, Formatting.Indented));

            Console.WriteLine($"Is Chain Valid: {crimCoin.IsValid()}");

            Console.WriteLine($"Update amount to 100");
            crimCoin.Chain[1].Data = "{sender:Frankie,receiver:Ushan,amount:100}";

            Console.WriteLine($"Is Chain Valid: {crimCoin.IsValid()}");

            Console.WriteLine($"Update hash");
            crimCoin.Chain[1].Hash = crimCoin.Chain[1].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {crimCoin.IsValid()}");

            Console.WriteLine($"Update the entire chain");
            crimCoin.Chain[2].PreviousHash = crimCoin.Chain[1].Hash;
            crimCoin.Chain[2].Hash = crimCoin.Chain[2].CalculateHash();
            crimCoin.Chain[3].PreviousHash = crimCoin.Chain[2].Hash;
            crimCoin.Chain[3].Hash = crimCoin.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {crimCoin.IsValid()}");

            Console.ReadKey();
        }
    }
}
