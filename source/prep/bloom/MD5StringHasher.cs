using System;
using System.Security.Cryptography;
using System.Linq;

namespace prep.bloom
{
    public class MD5StringHasher : IHashStrings
    {
        public int hash_word(string some_string)
        {
            return Math.Abs(some_string.GetHashCode() / 100000);
//            byte[] bytes_from_word = new byte[some_string.Length];
//            for (int i = 0; i < some_string.Length; i++)
//            {
//                bytes_from_word[i] = (byte)some_string[i];
//            }
//
//            MD5 md5 = MD5.Create();
//            byte[] hash = md5.ComputeHash(bytes_from_word);
//            return hash.Sum();
        }
    }
}