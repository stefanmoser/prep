using System.Collections.Generic;

namespace prep.bloom
{
    public class BloomFilter
    {
        readonly IHashStrings string_hasher;
        byte[] array;
        const int array_size = 256;

        public BloomFilter(IHashStrings string_hasher)
        {
            this.string_hasher = string_hasher;
            array = new byte[array_size];
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
            IEnumerable<int> word_hash = string_hasher.hash_word(possbile_word);

            foreach (var index in word_hash)
            {
                if (array[index] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void insert_word_into_hash(string word)
        {
           IEnumerable< int> hash = string_hasher.hash_word(word);

            foreach (var index in hash)
            {
                array[index] = 1;
            }
        }
    }
}