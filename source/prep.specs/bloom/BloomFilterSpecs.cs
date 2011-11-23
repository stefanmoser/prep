using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace prep.bloom
{
    [Subject(typeof(BloomFilter))]
    public class BloomFilterSpecs
    {
        public abstract class bloom_filter_concern : Observes<BloomFilter>
        {
            protected static BloomFilter bloom_filter;
            protected static List<string> dictionary = new List<string>();

            protected static List<string> words = new List<string>(){"hi", "there", "develop", "with", "passion"};
            protected static List<string> not_words = new List<string>(){"asdf", "qwer", "ZXC", "hkghkj", "asdf"};

            protected static string existing_word = "passion";
            protected static string non_existent_word = "blah_blah_blah";

            Establish context = () => bloom_filter = new BloomFilter(new MD5StringHasher());
        }

        public class given_a_fully_initialized_dictionary : bloom_filter_concern
        {
            Establish context = () =>
                                {
                                    bloom_filter.initialize_with(words);
                                };
        }

        public class when_checking_the_dictionary_for_an_existing_word : given_a_fully_initialized_dictionary
        {
            static bool is_word_in_dictionary;

            Because of = () => is_word_in_dictionary = bloom_filter.check_for_word_in_dictionary(existing_word);

            It should_match_the_word = () => is_word_in_dictionary.ShouldBeTrue();
        }

        public class when_checking_the_dictionary_for_a_nonexistent_word : given_a_fully_initialized_dictionary
        {
            static bool is_word_in_dictionary;

            Because of = () => is_word_in_dictionary = bloom_filter.check_for_word_in_dictionary(non_existent_word);

            It should_not_match_the_word = () => is_word_in_dictionary.ShouldBeFalse();
        }
    }
}