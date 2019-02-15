using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableConsole
{
     class HashNode <Tkey, Tvalue> {
        public Tkey Key { get; set; }
        public Tvalue Value { get; set; }

        public  HashNode(Tkey key, Tvalue value) {
            Key = key;
            Value = value;
        }

    }
    class HashTableLite<Tkey, Tvalue> {
        //Linked list of item chains 
        private LinkedList<HashNode<Tkey, Tvalue>>[] _hashBucketList; 

        //Number of hash buckets
        private int _numHashBuckets;

        //Linked list Size
        private int _size; 

        public HashTableLite() {
            _numHashBuckets = 10; //Create 10 hash buckets 
            _size = 0;

            _hashBucketList = new LinkedList<HashNode<Tkey, Tvalue>>[_numHashBuckets];
        }

        public int Size() { return _size; }

        public bool IsEmpty() { return Size() == 0; }

        //Implement the Hash Key Function 
        //To get the HashBucket Key - Use C# GetHashCode function and then modulo operator with 
        //Bucket size number 
        private int GetHashBucketIndex(Tkey key) {
            int hashCode = key.GetHashCode();
            int index = Math.Abs(hashCode % _numHashBuckets);
            return index;
        }

        public Tvalue GetKeyValue(Tkey key) {
            Tvalue currentValue=default(Tvalue);
            int bucketIndex = GetHashBucketIndex(key);

            var currentListItem = _hashBucketList[bucketIndex];
            foreach (var item in currentListItem) {
                if(item.Key.Equals(key)) {
                    currentValue = item.Value;
                }
            }
            return currentValue;
        }

        public void AddItem(Tkey key, Tvalue value ) {
            //First get the HashBucket index 
            int bucketIndex = GetHashBucketIndex(key);

            //Check if this bucket is empty or it's already initialized 
            //If bucket position is not already initialized
            if (_hashBucketList[bucketIndex]==null) {
                //Check if key is already in the list, if so, jsut update the value 
                _hashBucketList[bucketIndex] = new LinkedList<HashNode<Tkey, Tvalue>>();
            }

            //Add the current item to the hash table element 
            _hashBucketList[bucketIndex].AddFirst(new HashNode<Tkey, Tvalue>(key, value));
            ++_size;

            //Check if key already exists 
            var currentColletion = _hashBucketList[bucketIndex];
            foreach (var item in currentColletion) {
                
            }

            //Now increase the bucket list size if size exceeds threshold 0.7. i.e. size/Bucket Size
        }
    }
}
