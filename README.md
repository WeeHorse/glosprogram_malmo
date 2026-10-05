# Glosprogram

Ett konsolprogram som översätter glosor från svenska till andra språk. Just nu finns ordlistor för engelska och spanska.

## Starta programmet

Programmet kräver .NET 10. Starta det från projektmappen:

```
dotnet run
```

Kör det från projektmappen, eftersom programmet letar efter ordlistorna i `./wordlists/`.

När programmet startar skriver det ut hur många ord som har lästs in och från hur många filer, till exempel `197 ord inlästa från 2 filer`.

## Använda programmet

1. Programmet skriver `Ange vilket ord du vill översätta`.
2. Skriv ett ord på källspråket och tryck Enter. Med de ordlistor som finns nu är det svenska.
3. Programmet skriver ut översättningarna från alla ordlistor, en per rad. Om ordet har flera översättningar (synonymer) visas alla.
4. Om ordet saknas i alla ordlistor visas `Ordet finns inte i någon ordlista`.
5. Programmet frågar sedan efter nästa ord.

Det spelar ingen roll om du skriver med stora eller små bokstäver. `hus`, `Hus` och `HUS` ger samma svar.

Exempel:

```
Glosprogram
197 ord inlästa från 2 filer
Ange vilket ord du vill översätta
hund
perro
dog
Ange vilket ord du vill översätta
hus
casa
edificio
house
building
```

Översättningarna från de olika språken visas tillsammans, utan att det står vilket språk de kommer från.

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

Lägg en ny fil i `wordlists/`, till exempel `swedish-german.csv`, och starta om programmet. Koden behöver inte ändras.

Orden i den nya filen slås upp på källspråket i filnamnet. En fil som heter `english-swedish.csv` gör alltså att du kan skriva engelska ord.

## Begränsningar

- Det går inte att välja språk. Översättningarna från alla ordlistor visas tillsammans.
- Det går bara att översätta från källspråket i filnamnet, inte åt andra hållet.
- Varje rad i ordlistan måste innehålla ett kommatecken. Tomma rader eller rader utan kommatecken får programmet att krascha vid start.
- Filnamnet måste innehålla ett bindestreck, annars kraschar programmet vid start. Ett filnamn med flera bindestreck, till exempel `swedish-english-gammal.csv`, läses in utan varning och ger dubbletter. Lägg därför inte säkerhetskopior av ordlistor i `wordlists/`.
- Om man trycker **Ctrl+D** kraschar programmet i stället för att avslutas.

Mer om kända fel finns i [bugs/](bugs/README.md).
