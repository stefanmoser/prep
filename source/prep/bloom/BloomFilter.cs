using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace prep.bloom
{
    public class BloomFilter
    {
        readonly IHashStrings string_hasher;
        List<int> array;

        public BloomFilter(IHashStrings string_hasher)
        {
            this.string_hasher = string_hasher;
            array = new List<int>();
        }

        public void initialize_with(IEnumerable<string> dictionary)
        {
            foreach (var word in dictionary)
            {
                insert_word_into_hash(word);
            }
        }

        public bool check_for_word_in_dictionary(string possbile_word)
        {
            int word_hash = string_hasher.hash_word(possbile_word);
            ensure_array_size(word_hash);
            return array[word_hash] == 1;
        }

        private void ensure_array_size(int index)
        {
            while (index >= array.Count)
            {
                array.Add(0);
            }
        }

        private void insert_word_into_hash(string word)
        {
            int hash = string_hasher.hash_word(word);
            ensure_array_size(hash);

            Debug.WriteLine("Capacity: {0} Index: {1}", array.Count, hash);
            Console.WriteLine("Capacity: {0} Index: {1}", array.Count, hash);

            array[hash] = 1;
        }
    }
}