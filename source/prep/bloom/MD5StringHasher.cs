using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace prep.bloom
{
    public class MD5StringHasher : IHashStrings
    {
        public IEnumerable<int> hash_word(string some_string)
        {
            byte[] bytes_from_word =  build_byte_array(some_string);

            var hash = get_byte_array_hash(bytes_from_word);

            return hash.Cast<int>();
        }

        private byte[] get_byte_array_hash(byte[] bytes_from_word)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(bytes_from_word);
            return hash;
        }

        private byte[] build_byte_array(string some_string)
        {
            return some_string.ToCharArray().Cast<byte>().ToArray();
        }
    }
}