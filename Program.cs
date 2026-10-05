Console.WriteLine("Glosprogram");

List<Word> words = [];

// UC1: sökvägen ligger i en variabel så att vi kan läsa språken ur filnamnet
string filePath = "./wordlists/swedish-english.csv";

// UC1: plockar ut filnamnet utan mapp och ändelse (./wordlists/swedish-english.csv => swedish-english)
string fileName = Path.GetFileNameWithoutExtension(filePath);

// UC1: delar filnamnet vid bindestrecket (swedish-english => ["swedish", "english"])
string[] languages = fileName.Split("-");
string languageIn = languages[0];
string languageOut = languages[1];

// fyll listan med ord från disk (wordlists)
foreach (string line in File.ReadAllLines(filePath)) // UC1: använder variabeln filePath
{
  string[] wordPair = line.Split(",");
  words.Add(new Word(wordPair[0], wordPair[1], languageIn, languageOut)); // UC1: språken kommer från filnamnet i stället för hårdkodad text
}


// Dictionary

Dictionary<string, List<Word>> swedishToEnglish = words
.GroupBy(word => word.WordIn, StringComparer.OrdinalIgnoreCase) // skapar lista baserat på gemensam nyckel (i e stor => big, large)
.ToDictionary(
  group => group.Key, // nyckeln
  group => group.ToList(),          // värdet, typiskt hela objektet (referensen)
  StringComparer.OrdinalIgnoreCase
);


while (true)
{

  Console.WriteLine("Ange vilket ord du vill översätta");
  string? wordToTranslate = Console.ReadLine();

  // IF IT contains the key
  if (swedishToEnglish.ContainsKey(wordToTranslate!))
  {
    // loopa ut synonymer
    foreach (var word in swedishToEnglish[wordToTranslate!])
    {
      Console.WriteLine(word.WordOut);
    }
  }
  else
  {
    Console.WriteLine("This word does not exist in this dictionary");
  }

}






