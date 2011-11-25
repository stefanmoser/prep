using System.Collections.Generic;

namespace prep.bloom
{
    public interface IHashStrings
    {
        IEnumerable<int> hash_word(string some_string);
    }
}