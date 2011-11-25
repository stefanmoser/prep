namespace prep.bloom2
{
  public interface IConvertArrayTypes
  {
    byte[] convert_to_byte_array(char[] the_characters);
    int[] convert_to_int_array(byte[] the_bytes);
  }
}