
using System.Collections.Generic;
using System.Security.Cryptography;

namespace prep.bloom
{
    public class BloomFilter
    {
        private byte[] _array;
        private const int array_size = 256;

        public BloomFilter()
        {
            _array = new byte[array_size];
        }

        public void initialize_with(IEnumerable<string> dictionary)
        {
            foreach (var word in dictionary)
            {
                insert_word_into_hash(word);
            }
        }

        private void insert_word_into_hash(string word)
        {
            var hash = hash_word(word);

            foreach (byte b in hash)
            {
                _array[b] = 1;
            }
        }

        private static byte[] hash_word(string word)
        {
            byte[] bytes_from_word = new byte[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                bytes_from_word[i] = (byte) word[i];
            }

            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(bytes_from_word);
            return hash;
        }

        public bool check_word_in_dictionary(string possbile_word)
        {
            byte[] word_hash = hash_word(possbile_word);

            foreach (byte b in word_hash)
            {
                if (_array[b] == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}