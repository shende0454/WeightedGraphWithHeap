using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    class HeapEntry<KeyType, ValueType>
    {
        public HeapEntry(KeyType key, ValueType payload) 
        {
            Key = key;
            Payload = payload;
        }

        public KeyType Key { get; private set; }
        public ValueType Payload { get; private set; }
    }
}
