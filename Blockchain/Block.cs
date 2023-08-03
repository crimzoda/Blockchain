using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }

        //The block will be structured the way the parameters are structured
        public Block(DateTime timeStamp, string previousHash, string data)
        {
            //Index gives the block a unqieueness
            Index = 0;
            TimeStamp = timeStamp;
            //This will refer to the hash value of the previous block in the chain
            PreviousHash = previousHash;
            Data = data;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            //Using the SHA256 hashing alrogithm
            SHA256 sha256 = SHA256.Create();

            //Entire block gets hashed
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}--{PreviousHash ?? ""}--{Data}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}
