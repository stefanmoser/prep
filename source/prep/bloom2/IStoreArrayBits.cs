namespace prep.bloom2
{
  public interface IStoreArrayBits
  {
    void set_bits(int[] hash_values);
    bool contains_all_indices(int[] hash_values);
  }
}