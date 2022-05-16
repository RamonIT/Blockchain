using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    static internal class BlockchainLowLevel
    {
        const string GenesisBlockText = "GenesisBlock";

        public static Block CreateGenesisBlock()
        {
            byte[] PreviousBlockHash = BitConverter.GetBytes(0);
            byte[] BlockHash = HashBlock(PreviousBlockHash, GenesisBlockText, 0);

            return new Block(BlockHash, PreviousBlockHash, null, GenesisBlockText, 0);
        }

        public static byte[] HashBlock(byte[] PreviousBlockHash, string BlockData, int Nonce)
        {
            string PreviousHashString = BitConverter.ToString(PreviousBlockHash);
            string NonceString = Nonce.ToString();
            string CompleteBlock = PreviousHashString + NonceString + BlockData;

            byte[] NewBlockHash = HashData(CompleteBlock);
            return NewBlockHash;
        }

        public static byte[] HashData(string Data)
        {
            return new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(Data));
        }
    }
}
