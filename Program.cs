Console.WriteLine("Glosprogram");

/*
List<string> words = [
  "hus", "house",     // jämna index => svenskt uppslag, udda => engelsk översättning
  "hem", "home",
  "stor", "big",      // synonymer får hanteras i en loop
  "stor", "large"
];
*/

List<Word> words = [
  new Word("hus", "house", "swedish", "english"),
  new Word("hem", "home", "swedish", "english"),
  new Word("stor", "big", "swedish", "english"),
  new Word("stor", "large", "swedish", "english")
];

class Word(string wordIn, string wordOut, string languageIn, string languageOut)
{
  public string WordIn { get; } = wordIn;
  public string WordOUt { get; } = wordOut;
  public string LanguageIn { get; } = languageIn;
  public string LanguageOut { get; } = languageOut;
}





