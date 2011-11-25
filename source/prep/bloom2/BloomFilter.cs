namespace prep.bloom2
{
  public class BloomFilter : ISpellCheckerDictionary
  {
    IHashStrings hasher;
    IStoreArrayBits array_bits_store;

    public BloomFilter(IHashStrings hasher, IStoreArrayBits array_bits_store)
    {
      this.hasher = hasher;
      this.array_bits_store = array_bits_store;
    }

    public void add_word(string the_word)
    {
      int[] bit_indices = hasher.hash_word(the_word);
      array_bits_store.set_bits(bit_indices);
    }

    public bool check_word(string the_word)
    {
      int[] bit_indices = hasher.hash_word((the_word));
      return array_bits_store.contains_all_indices(bit_indices);
    }
  }
}