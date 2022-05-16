using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    internal class AdvancedBlockchainHighLevel
    {
        private LinkedList<Block> _blockChain;
        private List<Transaction> _transactions;
        private string _minerName;
        const int TransactionLimit = 8;
        const int Reward = 6;
        const int DifficultLevel = 2;

        public LinkedList<Block> Blockchain { get { return _blockChain; } }

        public AdvancedBlockchainHighLevel(string MinerName)
        {
            _blockChain = new LinkedList<Block>();
            _transactions = new List<Transaction>();
            _minerName = MinerName;
            _blockChain.AddLast(BlockchainLowLevel.CreateGenesisBlock());
        }

        public void AddTransaction(string Transaction)
        {
            _transactions.Add(new Transaction(Transaction, BlockchainLowLevel.HashData(Transaction)));

            if (_transactions.Count == TransactionLimit - 1)
            {
                string minerTransaction = $"{_minerName} Rewards {Reward} BTC";

                _transactions.Add(new Transaction(minerTransaction, BlockchainLowLevel.HashData(minerTransaction)));
                string transactionData = string.Join(Environment.NewLine, _transactions);
                byte[] markleRoot = GenerateBlockMarkleRoot(_transactions.Select(x => x.TransactionHash).ToList());

                _transactions.Clear();

                var previousBlock = _blockChain.Last.Value;
                var foundBlock = FindHashAndReturnBlock(transactionData, markleRoot, previousBlock.BlockHash);
                _blockChain.AddLast(foundBlock);
            }
        }

        private Block FindHashAndReturnBlock(string Transactions, byte[] MarkleRoot, byte[] PreviousHash)
        {
            int nonce = 0;

            while (nonce != int.MaxValue)
            {
                var newBlockHash = BlockchainLowLevel.HashBlock(PreviousHash, Transactions, nonce);

                // Checks the difficult level
                bool success = false;
                for (int i = 0; i < DifficultLevel; i++)
                {
                    // In case of any level that not starts with 0
                    // then exit and try next nonce
                    if(newBlockHash[i] == 0)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    return new Block(newBlockHash, PreviousHash, MarkleRoot, Transactions, nonce);
                }

                nonce++;
            }

            return null;
        }

        private byte[] GenerateBlockMarkleRoot(List<byte[]> hashList)
        {
            if (hashList.Count == 1)
            {
                return hashList[0];
            }
            var newHashList = new List<byte[]>();
            for (int i = 0; i < hashList.Count; i += 2)
            {
                newHashList.Add(MergeHash(hashList[i], hashList[i + 1]));
            }
            if (hashList.Count % 2 == 1)
            {
                newHashList.Add(MergeHash(hashList[-1], hashList[-1]));
            }
            return GenerateBlockMarkleRoot(newHashList);
        }

        private byte[] MergeHash(byte[] Hash1, byte[] Hash2)
        {
            var appendHash = Hash1.Concat(Hash2);
            return new SHA256Managed().ComputeHash(appendHash.ToArray());
        }
    }
}
