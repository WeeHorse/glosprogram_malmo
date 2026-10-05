# Prompthistorik

Prompterna som användes med Claude Code (Claude Opus 5.5) i den här sessionen, i den ordning de skrevs, med en kort sammanfattning av vad som gjordes.

## 1. Spansk ordlista

> kan du skapa en version av wordlist som är mellan svenska och spanska (med samma ord)

Skapade `wordlists/swedish-spanish.csv` med samma svenska ord som `swedish-english.csv`, och spanska synonymer på egna rader.

## 2. UC2

> Kan du bygga UC2?

Programmet läser nu alla `.csv`-filer i `wordlists/` med `Directory.GetFiles` och skriver ut hur många ord som lästs in från hur många filer.

## 3. Buggrapporter

> Kan du lägga buggrapporter i bugs?

Skapade `bugs/` med en översikt och sju buggrapporter (BUG1–BUG7). Varje rapport innehåller stegen för att återskapa buggen och vilken use case som löser den.

## 4. Krasch vid start

> Nu när jag körde koden fick jag en crash direkt:
>
> ```
> Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
>    at Program.<Main>$(String[] args) in /Users/b/Desktop/Projects/MAI26MA/glosprogram_malmo/Program.cs:line 23
> ```

Kraschen kom troligen från en tillfällig testfil med en tom rad (BUG2), som låg i `wordlists/` medan buggarna återskapades. Testfilen var redan borttagen, och programmet fungerade när det kördes igen.

## 5. README

> Har du uppdaterat manualen i README för att spegla förändringarna?

Det var inte gjort. README uppdaterades med flera ordlistor, ny exempelutskrift, hur man lägger till en ordlista och nya begränsningar.

## 6. Paritet mellan specs, README och programmet

> Utifrån en jämförelse mellan specs, README och programmet, är det något du inte har paritet i?

Gick igenom skillnaderna, bland annat fel siffra i en kommentar, rutor som inte var ibockade i UC1 och UC2, att BUG6 och BUG7 inte hörde till någon use case, och oprecisa formuleringar i README.

## 7. Åtgärda paritetsskillnaderna

> Kan du åtgärda dessa paritetsdifferenser

Rättade kommentaren, bockade av UC1 och UC2, lade till krav på bestämd ordning i UC3 (BUG7), bytte felmeddelandet till svenska (BUG6), ändrade `var` till `Word` och uppdaterade README och bugs.

## 8. Prompthistorik

> Kan du spara din prompt history i prompt-history.md?

Skapade den här filen.

## 9. Underhåll prompthistoriken

> Från och med nu, underhåll denna kontinuerligt. (Lägg in detta i din system prompt)

Systemprompten går inte att ändra. Regeln lades i stället i `CLAUDE.md` under rubriken *Prompthistorik*, eftersom den filen läses in i början av varje session.

## 10. UC3, UC4 och UC5

> Kan du bygga UC3, 4 och 5?

Byggdes ett steg i taget, och varje steg kördes och testades innan nästa påbörjades. Testerna med extra ordlistor kördes i en kopia av projektet.

- **UC3:** `Word` fick propertyn `LanguagePair` (t.ex. `swedish → english`). Språkparen plockas ut ur orden, sorteras i bokstavsordning och visas som en numrerad lista. Sorteringen åtgärdar BUG7.
- **UC4:** användaren väljer ett nummer, och ett ogiltigt val ger ett felmeddelande. `swedishToEnglish` ersattes av `translations`, som bara innehåller orden i det valda paret. Ctrl+D vid valet avslutar programmet, annars skulle frågan upprepas i all oändlighet.
- **UC5:** valet och översättningsloopen ligger i en yttre loop, och `:byt` går tillbaka till valet av språkpar.

Specs, README och bugs uppdaterades så att de stämmer med koden.

## 11. Kontroll av README

> Är README uppdaterad?

Exemplet i README kördes och utskriften jämfördes rad för rad. Den stämde. Meningen om stora och små bokstäver hade hamnat under *Byta språkpar* och flyttades tillbaka till avsnittet om att översätta ord. README säger nu också att `:byt` måste skrivas med små bokstäver.


## 12. Förslag på UC6

> Om du skulle göra UC6 för att översätta åt båda håll, hur skulle du göra den ändringen?

Ingen kod ändrades. Förslaget är att skapa ett omvänt `Word` för varje rad i inläsningsloopen, så att `english → swedish` kommer med automatiskt i språkparen och i `translations`. En risk togs upp: om det även finns en `english-swedish.csv` blir orden dubbletter.

## 13. UC6 genom att vända nyckeln

> Du skapar då dubbelt så många instanser av Word. Om du skulle vända nyckeln i GroupBy Dictionary istället, vad skulle du mer behöva ändra då?

Ingen kod ändrades. Om nyckeln vänds i stället för att orden dubbleras måste fyra ställen ändras: `Word` behöver ett omvänt språkpar, och språkparen behöver ta med det. Dessutom måste filtret med `Where`, nyckeln i `GroupBy` och utskriften av översättningen alla veta vilket håll som gäller. Svaret jämförde de två lösningarna.

## 14. Bygg UC6

> Okej då, kör dubbla Word

UC6 byggdes med dubbla `Word`. I inläsningsloopen skapas nu ett omvänt `Word` för varje rad, så att `english → swedish` och `spanish → swedish` kommer med automatiskt. Programmet kördes och testades: `big` och `LARGE` ger `stor`, och både `house` och `building` ger `hus`. Riktningen `swedish → spanish` fungerar som innan. Rutorna i UC6-specen bockades av. README uppdaterades med de nya språkparen, de nya numren, antalet ord (394), ett nytt exempel och den nya begränsningen: filer åt båda hållen ger dubbletter.

## 15. Spec för UC8

> Kan du skapa en UC8 som innebär att vi vill kunna extrapolera översättningar?

Ingen kod ändrades. En ny spec, `specs/UC8-extrapolera-oversattningar.md`, skapades. Den beskriver hur programmet ska kunna översätta mellan två språk utan egen ordlista genom att gå via ett gemensamt språk, till exempel `house → hus → casa`. Specen bygger på UC6 och kräver bara ett mellanled. UC8 lades till i tabellen i `specs/README.md`.

## 16. Spansk-italiensk ordlista

> Kan du generera en spansk-italiensk ordlista också?

`wordlists/spanish-italian.csv` skapades med 100 rader. Den innehåller alla 97 spanska ord från `swedish-spanish.csv`, så att UC8 senare kan översätta till exempel `swedish → italian` via spanska. Några ord har synonymer, till exempel `coche,macchina` och `coche,auto`. Programmet kördes: `594 ord inlästa från 3 filer`, och paren `spanish → italian` och `italian → spanish` visas och fungerar (`perro` ger `cane`, `bello` ger `bonito` och `hermoso`). README uppdaterades med den nya filen, antalet ord och de nya numren på språkparen.
