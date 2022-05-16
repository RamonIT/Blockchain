using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] PreviousBlockHash = BitConverter.GetBytes(0);
            string TransactionData = "MyTransactionData";
            int Nonce = 0;

            //BlockchainLowLevel.HashBlock(PreviousBlockHash, TransactionData, Nonce);
            //BlockchainHighLevel Blockchain = new BlockchainHighLevel();
            //Blockchain.AddBlock("test");

            var Blockchain = new AdvancedBlockchainHighLevel("Ramon");
            Blockchain.AddTransaction("Test 1");
            Blockchain.AddTransaction("Test 2");
            Blockchain.AddTransaction("Test 3");
            Blockchain.AddTransaction("Test 4");
            Blockchain.AddTransaction("Test 5");
            Blockchain.AddTransaction("Test 6");
            Blockchain.AddTransaction("Test 7");
        }
    }
}
