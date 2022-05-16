using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BlockChain
{
    internal class Block
    {
        private byte[] _blockHash;
        private byte[] _previousBlockHash;
        private byte[] _markleRoot;
        private string _data;
        private int _nonce;

        public byte[] BlockHash { get { return _blockHash; } }

        public byte[] PreviousBlockHash { get { return _previousBlockHash; } }

        public byte[] MarkleRoot { get { return _markleRoot; } }

        public string Data { get { return _data; } }

        public int Nonce { get { return _nonce; } }

        public Block(byte[] BlockHash, byte[] PreviousBlockHash, byte[] MarkleRoot, string Data, int Nonce = 0)
        {
            _blockHash = BlockHash;
            _previousBlockHash = PreviousBlockHash;
            _data = Data;
            _nonce = Nonce;
            _markleRoot = MarkleRoot;
        }
    }
}
