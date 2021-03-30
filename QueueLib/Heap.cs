using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    public class Heap<KeyType, ValueType> : IHeap<KeyType, ValueType>
        where KeyType : IComparable<KeyType>
    {
        public Heap(IComparer<KeyType> comparer)
        {
            Comparer = comparer;

            // Burn the zero location.  We want a 1 based array.
            theHeap.Add(new HeapEntry<KeyType, ValueType>(default(KeyType),
                default(ValueType)));
        }

        public bool IsEmpty()
        {
            return theHeap.Count == 1;
        }

        public void swim(int childIndex)
        {
            int parentIndex = childIndex / 2;
            if (parentIndex >= 0)
            {
                if (Comparer.Compare(theHeap[parentIndex].Key,
                    theHeap[childIndex].Key) < 0)
                {
                    // Swap parent and child
                    var temp = theHeap[parentIndex];
                    theHeap[parentIndex] = theHeap[childIndex];
                    theHeap[childIndex] = temp;

                    swim(parentIndex);
                }
            }
        }

        public void sink(int parentIndex)
        {
            int childIndex = 2 * parentIndex;
            if (childIndex < theHeap.Count)
            {
                if (childIndex + 1 < theHeap.Count)
                {
                    childIndex = (Comparer.Compare(theHeap[parentIndex * 2].Key,
                        theHeap[parentIndex * 2 + 1].Key) > 0) ?
                         parentIndex * 2 : parentIndex * 2 + 1;
                }

                if (Comparer.Compare(theHeap[parentIndex].Key,
                    theHeap[childIndex].Key) < 0)
                {
                    // Swap the parent and child
                    var temp = theHeap[parentIndex];
                    theHeap[parentIndex] = theHeap[childIndex];
                    theHeap[childIndex] = temp;
                    sink(childIndex);
                }
            }
        }

        public bool MaxIsFirst { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dequeue(out KeyType key, out ValueType payload)
        {
            key = theHeap[1].Key;
            payload = theHeap[1].Payload;

            // If the heap is not empty.
            if (theHeap.Count > 1)
            {
                // Move the last element to the top.
                theHeap[1] = theHeap[theHeap.Count - 1];
                theHeap.RemoveAt(theHeap.Count - 1);
                sink(1);
            }
        }

        public void Enqueue(KeyType key, ValueType payload)
        {
            var newEntry = new HeapEntry<KeyType, ValueType>(key, payload);
            theHeap.Add(newEntry);
            swim(theHeap.Count() - 1);
        }

        IComparer<KeyType> Comparer;

        List<HeapEntry<KeyType, ValueType>> theHeap = new
            List<HeapEntry<KeyType, ValueType>>();
    }
}
