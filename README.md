# Glosprogram

Ett konsolprogram som översätter glosor från svenska till andra språk. Just nu finns ordlistor för engelska och spanska.

## Starta programmet

Programmet kräver .NET 10. Starta det från projektmappen:

```
dotnet run
```

Kör det från projektmappen, eftersom programmet letar efter ordlistorna i `./wordlists/`.

När programmet startar skriver det ut hur många ord som har lästs in och från hur många filer, till exempel `197 ord inlästa från 2 filer`. Sedan visas en numrerad lista över språkparen som finns.

## Använda programmet

1. Välj språkpar genom att skriva numret från listan och trycka Enter. Skriver du något annat än ett nummer i listan visas `Ogiltigt val` och du får välja igen.
2. Programmet skriver vilket språkpar du har valt, till exempel `Du översätter nu swedish → spanish`, och frågar efter ett ord.
3. Skriv ett ord på källspråket och tryck Enter. Med de ordlistor som finns nu är det svenska.
4. Programmet skriver ut översättningarna i det valda språkparet, en per rad. Om ordet har flera översättningar (synonymer) visas alla.
5. Om ordet saknas visas till exempel `Ordet finns inte i ordlistan för swedish → spanish`.
6. Programmet frågar sedan efter nästa ord.

Det spelar ingen roll om du skriver med stora eller små bokstäver. `hus`, `Hus` och `HUS` ger samma svar.

### Byta språkpar

Skriv `:byt` i stället för ett ord. Då visas listan med språkpar igen och du kan välja ett nytt, utan att starta om programmet. Skriv kommandot med små bokstäver, `:BYT` fungerar inte.

Exempel:

```
Glosprogram
197 ord inlästa från 2 filer
Språkpar:
1. swedish → english
2. swedish → spanish
Välj språkpar genom att skriva dess nummer
2
Du översätter nu swedish → spanish
Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)
stor
grande
enorme
voluminoso
Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)
:byt
Språkpar:
1. swedish → english
2. swedish → spanish
Välj språkpar genom att skriva dess nummer
1
Du översätter nu swedish → english
Ange vilket ord du vill översätta (skriv :byt för att byta språkpar)
hund
dog
```

Språkparen visas i bokstavsordning, så samma nummer betyder alltid samma språkpar.

## Avsluta programmet

Programmet har inget kommando för att avsluta. Tryck **Ctrl+C** för att stänga det.

## Ordlistorna

Programmet läser in alla `.csv`-filer i mappen `wordlists/`. Just nu finns:

- `swedish-english.csv` – svenska till engelska
- `swedish-spanish.csv` – svenska till spanska

Varje rad är ett ordpar, med ordet först och översättningen efter ett kommatecken:

```
hus,house
hus,building
stor,big
```

Om ett ord har flera översättningar skriver du en rad för varje översättning, med samma svenska ord först.

Språken hämtas från filnamnet: `swedish-english.csv` betyder från svenska till engelska. Filnamnet ska ha formen `källspråk-målspråk.csv`, med språknamnen på engelska och med gemener.

### Lägga till en ny ordlista

Lägg en ny fil i `wordlists/`, till exempel `swedish-german.csv`, och starta om programmet. Det nya språkparet visas då i listan. Koden behöver inte ändras.

Orden i den nya filen slås upp på källspråket i filnamnet. En fil som heter `english-swedish.csv` gör alltså att du kan skriva engelska ord.

## Begränsningar

- Det går bara att översätta från källspråket i filnamnet, inte åt andra hållet.
- Varje rad i ordlistan måste innehålla ett kommatecken. Tomma rader eller rader utan kommatecken får programmet att krascha vid start.
- Filnamnet måste innehålla ett bindestreck, annars kraschar programmet vid start. Ett filnamn med flera bindestreck, till exempel `swedish-english-gammal.csv`, läses in utan varning och ger dubbletter. Lägg därför inte säkerhetskopior av ordlistor i `wordlists/`.
- Om man trycker **Ctrl+D** när programmet frågar efter ett ord kraschar det i stället för att avslutas. När programmet frågar efter språkpar avslutas det som det ska.

Mer om kända fel finns i [bugs/](bugs/README.md).
