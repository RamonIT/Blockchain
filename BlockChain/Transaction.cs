using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    internal class Transaction
    {
        private string _transactionData;
        private byte[] _transactionHash;

        public string TransactionData { get { return _transactionData; } }
        public byte[] TransactionHash { get { return _transactionHash; } }

        public Transaction(string TransactionData, byte[] TransactionHash)
        {
            _transactionData = TransactionData;
            _transactionHash = TransactionHash;
        }

        public override string ToString()
        {
            return $"{_transactionData}{Environment.NewLine}{BitConverter.ToString(_transactionHash)}"; // Default endiannes should be little endian
        }
    }
}
