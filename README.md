# Glosprogram

Ett konsolprogram som översätter glosor mellan olika språk, åt båda hållen. Just nu finns ordlistor för svenska–engelska, svenska–spanska och spanska–italienska.

## Starta programmet

Programmet kräver .NET 10. Starta det från projektmappen:

```
dotnet run
```

Kör det från projektmappen, eftersom programmet letar efter ordlistorna i `./wordlists/`.

När programmet startar skriver det ut hur många ord som har lästs in och från hur många filer, till exempel `594 ord inlästa från 3 filer`. Varje rad i en ordlista räknas två gånger, en gång för varje håll. Sedan visas en numrerad lista över språkparen som finns.

## Använda programmet

1. Välj språkpar genom att skriva numret från listan och trycka Enter. Skriver du något annat än ett nummer i listan visas `Ogiltigt val` och du får välja igen.
2. Programmet skriver vilket språkpar du har valt, till exempel `Du översätter nu swedish → spanish`, och frågar efter ett ord.
3. Skriv ett ord på det första språket i paret och tryck Enter. Har du valt `english → swedish` skriver du alltså ett engelskt ord.
4. Programmet skriver ut översättningarna i det valda språkparet, en per rad. Om ordet har flera översättningar (synonymer) visas alla.
5. Om ordet saknas visas till exempel `Ordet finns inte i ordlistan för swedish → spanish`.
6. Programmet frågar sedan efter nästa ord.

Det spelar ingen roll om du skriver med stora eller små bokstäver. `hus`, `Hus` och `HUS` ger samma svar.

### Byta språkpar

Skriv `:byt` i stället för ett ord. Då visas listan med språkpar igen och du kan välja ett nytt, utan att starta om programmet. Skriv kommandot med små bokstäver, `:BYT` fungerar inte.

Exempel:

```
Glosprogram
594 ord inlästa från 3 filer
Språkpar:
1. english → swedish
2. italian → spanish
3. spanish → italian
4. spanish → swedish
5. swedish → english
6. swedish → spanish
Välj språkpar genom att skriva dess nummer
6
Du översätter nu swedish → spanish
Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)
stor
grande
enorme
voluminoso
Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)
:byt
Språkpar:
1. english → swedish
2. italian → spanish
3. spanish → italian
4. spanish → swedish
5. swedish → english
6. swedish → spanish
Välj språkpar genom att skriva dess nummer
1
Du översätter nu english → swedish
Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)
big
stor
```

Språkparen visas i bokstavsordning, så samma nummer betyder alltid samma språkpar.

## Avsluta programmet

Programmet har inget kommando för att avsluta. Tryck **Ctrl+C** för att stänga det.

## Ordlistorna

Programmet läser in alla `.csv`-filer i mappen `wordlists/`. Just nu finns:

- `swedish-english.csv` – svenska och engelska
- `swedish-spanish.csv` – svenska och spanska
- `spanish-italian.csv` – spanska och italienska

Varje fil ger två språkpar, ett för varje håll. `swedish-english.csv` ger både `swedish → english` och `english → swedish`.

Varje rad är ett ordpar, med ordet först och översättningen efter ett kommatecken:

```
hus,house
hus,building
stor,big
```

Om ett ord har flera översättningar skriver du en rad för varje översättning, med samma ord först.

Språken hämtas från filnamnet: `swedish-english.csv` betyder från svenska till engelska. Filnamnet ska ha formen `källspråk-målspråk.csv`, med språknamnen på engelska och med gemener.

### Lägga till en ny ordlista

Lägg en ny fil i `wordlists/`, till exempel `swedish-german.csv`, och starta om programmet. Det nya språkparet visas då i listan. Koden behöver inte ändras.

Det räcker med en fil per språk, eftersom programmet översätter åt båda hållen. Lägg inte till en `english-swedish.csv` om det redan finns en `swedish-english.csv`, för då visas varje översättning två gånger.

## Begränsningar

- Om det finns filer för samma språk åt båda hållen, till exempel både `swedish-english.csv` och `english-swedish.csv`, visas varje översättning två gånger.
- Varje rad i ordlistan måste innehålla ett kommatecken. Tomma rader eller rader utan kommatecken får programmet att krascha vid start.
- Filnamnet måste innehålla ett bindestreck, annars kraschar programmet vid start. Ett filnamn med flera bindestreck, till exempel `swedish-english-gammal.csv`, läses in utan varning och ger dubbletter. Lägg därför inte säkerhetskopior av ordlistor i `wordlists/`.
- Om man trycker **Ctrl+D** när programmet frågar efter ett ord kraschar det i stället för att avslutas. När programmet frågar efter språkpar avslutas det som det ska.

Mer om kända fel finns i [bugs/](bugs/README.md).
