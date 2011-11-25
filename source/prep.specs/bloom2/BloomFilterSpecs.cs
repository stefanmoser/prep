using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using prep.bloom2;

namespace prep.specs.bloom2
{
  [Subject(typeof(BloomFilter))]
  public class BloomFilterSpecs
  {
    public class concern : Observes<ISpellCheckerDictionary, BloomFilter>
    {
      public class when_adding_a_word_to_the_dictionary : concern
      {
        Establish context = () =>
        {
          the_word = "go canucks!!";
          hash_values = new[]{1,2,3,4,5};

          hasher = depends.on<IHashStrings>();
          array_store = depends.on<IStoreArrayBits>();
          
          hasher.setup(x => x.hash_word(the_word)).Return(hash_values);
        };

        Because of = () =>
          sut.add_word(the_word);

        It should_hash_the_word = () =>
          hasher.received(x => x.hash_word(the_word));

        It should_set_the_hash_bits_in_the_store = () =>
          array_store.received(x => x.set_bits(hash_values));

        static IHashStrings hasher;
        static string the_word;
        static IStoreArrayBits array_store;
        static int[] hash_values;
      }

      public class when_looking_up_a_word_in_the_dictionary : concern
      {
        Establish context = () =>
        {
          hash_values = new[] { 1, 2, 3, 4, 5 };
          the_word = "go canucks!!";
          
          hasher = depends.on<IHashStrings>();
          array_store = depends.on<IStoreArrayBits>();

          hasher.setup((x => x.hash_word(the_word))).Return(hash_values);
        };

        Because of = () =>
          sut.check_word(the_word);
        
        It should_hash_the_word = () =>
          hasher.received(x => x.hash_word(the_word));

        It should_get_the_bits_in_the_store = () =>
          array_store.received(x => x.contains_all_indices(hash_values));

        static IHashStrings hasher;
        static string the_word;
        static IStoreArrayBits array_store;
        static int[] hash_values;
      }
    }
  }
}