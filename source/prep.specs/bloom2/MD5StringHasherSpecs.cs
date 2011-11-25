using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using prep.bloom2;

namespace prep.specs.bloom2
{
  [Subject(typeof(MD5StringHasher))]
  public class MD5StringHasherSpecs
  {
     public class concern : Observes<IHashStrings,
       MD5StringHasher>
     {
       public class when_hashing_a_string : concern
       {
         Establish context = () =>
          {
            the_word = "go canucks!";

            array_type_converter = depends.on<IConvertArrayTypes>();
          };

         Because of = () =>
           sut.hash_word(the_word);
         
         It should_convert_the_string_byte_array_into_an_int_array = () =>
           array_type_converter.received(x => x.convert_to_byte_array(Arg<char[]>.Is.NotNull));

         It should_convert_the_hashed_bytes_into_integers = () =>
           array_type_converter.received(x => x.convert_to_int_array(Arg<byte[]>.Is.NotNull));

         static IConvertArrayTypes array_type_converter;
         static char[] the_characters;
         static string the_word;
       }
     }
  }
}