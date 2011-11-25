using System.Security.Cryptography;

namespace prep.bloom2
{
  public class MD5StringHasher : IHashStrings
  {
    IConvertArrayTypes array_type_converter;

    public MD5StringHasher(IConvertArrayTypes arrayTypeConverter)
    {
      array_type_converter = arrayTypeConverter;
    }

    public int[] hash_word(string the_word)
    {
      char[] the_characters = the_word.ToCharArray();
      byte[] the_bytes = array_type_converter.convert_to_byte_array(the_characters);

      MD5 md5 = new MD5CryptoServiceProvider();
      byte[] the_hashed_bytes = md5.ComputeHash(the_bytes);

      return array_type_converter.convert_to_int_array(the_hashed_bytes);
    }
  }
}