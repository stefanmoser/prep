namespace prep.bloom2
{
  public interface ISpellCheckerDictionary
  {
    void add_word(string the_word);
    bool check_word(string the_word);
  }
}