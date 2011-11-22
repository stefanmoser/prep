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

            Establish context = () => bloom_filter = new BloomFilter();
        }

        public class when_initializing_with_no_words : bloom_filter_concern
        {
           
            private Because of = () => bloom_filter.initialize_with(dictionary);

            private It should_not_match_words = () =>
                                                    {
                                                        foreach (var possible_word in words)
                                                        {
                                                            bool is_in_dictionary = bloom_filter.check_word_in_dictionary(possible_word);
                                                            is_in_dictionary.ShouldBeFalse();
                                                        }
                                                    };
        }

        public class when_initializing_with_one_word : bloom_filter_concern
        {
            private Because of = () => bloom_filter.initialize_with(new[] {"regina"});

            private It should_match_the_word = () => bloom_filter.check_word_in_dictionary("regina").ShouldBeTrue();

            private It should_not_match_other_words = () =>
                                                          {
                                                              foreach (var possible_word in words)
                                                              {
                                                                  bloom_filter.check_word_in_dictionary(possible_word).ShouldBeFalse();
                                                              }
                                                          };
            It should_not_match_an_empty_string = () =>
        }



//            public abstract class movie_library_concern : Observes<MovieLibrary>
//    {
//      protected static IList<Movie> movie_collection;
//
//      Establish c = () =>
//      {
//        movie_collection = new List<Movie>();
//        depends.on(movie_collection);
//      };
//    };
//
//    public class when_iterating : movie_library_concern
//    { 
    }
}