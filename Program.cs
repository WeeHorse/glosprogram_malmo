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

    // UC6: lägger också till ordet åt andra hållet, så att samma fil räcker för båda riktningarna (house => hus)
    words.Add(new Word(wordPair[1], wordPair[0], languageOut, languageIn));
  }
}

// UC2: visar att orden från alla filer har lästs in (t.ex. 197 ord från 2 filer)
Console.WriteLine($"{words.Count} ord inlästa från {filePaths.Length} filer");

// UC3: plockar ut alla språkpar som finns bland orden, utan dubbletter
// Order sorterar i bokstavsordning, så att samma nummer alltid betyder samma språkpar
List<string> languagePairs = words
  .Select(word => word.LanguagePair)
  .Distinct()
  .Order()
  .ToList();

// UC5: yttre loop, så att användaren kan komma tillbaka hit och välja ett nytt språkpar med :byt
while (true)
{
  // UC3: skriver ut språkparen som en numrerad lista som börjar på 1
  Console.WriteLine("Språkpar:");
  for (int i = 0; i < languagePairs.Count; i++)
  {
    Console.WriteLine($"{i + 1}. {languagePairs[i]}");
  }


  // UC4: frågar efter ett nummer tills användaren har valt ett språkpar som finns
  string chosenLanguagePair = "";
  while (true)
  {
    Console.WriteLine("Välj språkpar genom att skriva dess nummer");
    string? choice = Console.ReadLine();

    // UC4: inmatningen har tagit slut (t.ex. Ctrl+D), annars skulle frågan upprepas i all oändlighet
    if (choice == null)
    {
      return;
    }

    // UC4: TryParse försöker göra om texten till ett tal och ger false om det inte går (t.ex. "abc")
    if (int.TryParse(choice, out int chosenNumber) && chosenNumber >= 1 && chosenNumber <= languagePairs.Count)
    {
      chosenLanguagePair = languagePairs[chosenNumber - 1]; // listan börjar på 0, men numren börjar på 1
      break;
    }

    Console.WriteLine($"Ogiltigt val, skriv ett nummer mellan 1 och {languagePairs.Count}");
  }

  Console.WriteLine($"Du översätter nu {chosenLanguagePair}");


  // Dictionary

  // UC4: ersätter swedishToEnglish och fungerar för alla språkpar, eftersom bara orden i det valda paret tas med
  Dictionary<string, List<Word>> translations = words
    .Where(word => word.LanguagePair == chosenLanguagePair)
    .GroupBy(word => word.WordIn, StringComparer.OrdinalIgnoreCase) // skapar lista baserat på gemensam nyckel (i e stor => big, large)
    .ToDictionary(
      group => group.Key, // nyckeln
      group => group.ToList(),          // värdet, typiskt hela objektet (referensen)
      StringComparer.OrdinalIgnoreCase
    );


  while (true)
  {

    Console.WriteLine("Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)"); // UC5: berättar om kommandot
    string? wordToTranslate = Console.ReadLine();

    // UC5: break lämnar bara den inre loopen, så programmet hoppar tillbaka till valet av språkpar
    if (wordToTranslate == ":byt")
    {
      break;
    }

    // om ordet finns som nyckel i dictionaryt
    if (translations.ContainsKey(wordToTranslate!))
    {
      // loopa ut synonymer
      foreach (Word word in translations[wordToTranslate!])
      {
        Console.WriteLine(word.WordOut);
      }
    }
    else
    {
      Console.WriteLine($"Ordet finns inte i ordlistan för {chosenLanguagePair}"); // UC4: visar vilket par som söktes i
    }

  }
}
