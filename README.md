# Glosprogram

Ett konsolprogram som översätter glosor från svenska till engelska.

## Starta programmet

Programmet kräver .NET 10. Starta det från projektmappen:

```
dotnet run
```

Kör det från projektmappen, eftersom programmet letar efter ordlistan i `./wordlists/`.

## Använda programmet

1. Programmet skriver `Ange vilket ord du vill översätta`.
2. Skriv ett svenskt ord och tryck Enter.
3. Programmet skriver ut översättningen. Om ordet har flera översättningar (synonymer) visas alla, en per rad.
4. Om ordet saknas i ordlistan visas `This word does not exist in this dictionary`.
5. Programmet frågar sedan efter nästa ord.

Det spelar ingen roll om du skriver med stora eller små bokstäver. `hus`, `Hus` och `HUS` ger samma svar.

Exempel:

```
Glosprogram
Ange vilket ord du vill översätta
stor
big
large
Ange vilket ord du vill översätta
hus
house
building
```

## Avsluta programmet

Programmet har inget kommando för att avsluta. Tryck **Ctrl+C** för att stänga det.

## Ordlistan

Orden läses från filen `wordlists/swedish-english.csv`. Varje rad är ett ordpar, med det svenska ordet först och den engelska översättningen efter ett kommatecken:

```
hus,house
hus,building
stor,big
```

Om ett ord har flera översättningar skriver du en rad för varje översättning, med samma svenska ord först.

Språken hämtas från filnamnet: `swedish-english.csv` betyder från svenska till engelska.

## Begränsningar

- Programmet läser bara filen `swedish-english.csv`. Andra filer i `wordlists/` används inte än.
- Det går bara att översätta från svenska till engelska.
- Varje rad i ordlistan måste innehålla ett kommatecken. Tomma rader eller rader utan kommatecken får programmet att krascha vid start.
