Console.WriteLine("Glosprogram");

List<Word> words = [];

// UC2: hämtar sökvägarna till alla .csv-filer i mappen, så att en ny ordlista kommer med utan att koden ändras
string[] filePaths = Directory.GetFiles("./wordlists", "*.csv");

// UC2: läser in en fil i taget, och orden från alla filer hamnar i samma lista
foreach (string filePath in filePaths)
{
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
}

// UC2: visar att orden från alla filer har lästs in (t.ex. 197 ord från 2 filer)
Console.WriteLine($"{words.Count} ord inlästa från {filePaths.Length} filer");


// Dictionary
// innehåller just nu ord från alla ordlistor, trots namnet (ersätts i UC4)

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

  // om ordet finns som nyckel i dictionaryt
  if (swedishToEnglish.ContainsKey(wordToTranslate!))
  {
    // loopa ut synonymer
    foreach (Word word in swedishToEnglish[wordToTranslate!])
    {
      Console.WriteLine(word.WordOut);
    }
  }
  else
  {
    Console.WriteLine("Ordet finns inte i någon ordlista");
  }

}






