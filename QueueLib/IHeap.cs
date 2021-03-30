using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    interface IHeap<KeyType, ValueType> where KeyType : IComparable<KeyType>
    {
        void Enqueue(KeyType key, ValueType thingToEnqueue);
        bool IsEmpty();
        void Dequeue(out KeyType key, out ValueType payload);
    }
}
