using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    internal class BlockchainHighLevel
    {
        private LinkedList<Block> _blockChain;

        public LinkedList<Block> BlockChain { get { return _blockChain; } }

        public BlockchainHighLevel()
        {
            _blockChain = new LinkedList<Block>();
            _blockChain.AddLast(BlockchainLowLevel.CreateGenesisBlock());
        }

        public void AddBlock(string DataToAdd)
        {
            //var lastBlock = _blockChain.Last.Value;
            //var newBlockHash = BlockchainLowLevel.HashBlock(lastBlock.BlockHash, DataToAdd, lastBlock.Nonce);
            //var newBlock = new Block(newBlockHash, lastBlock.BlockHash, DataToAdd, lastBlock.Nonce + 1);
            //_blockChain.AddLast(newBlock);
        }
    }
}
