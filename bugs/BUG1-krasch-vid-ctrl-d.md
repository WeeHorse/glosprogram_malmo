# BUG1: Krasch när inmatningen tar slut (Ctrl+D)

## Steg för att återskapa
1. Starta programmet med `dotnet run`.
2. Tryck Ctrl+D (macOS/Linux) eller Ctrl+Z och Enter (Windows) när programmet frågar efter ett ord.

## Förväntat
Programmet avslutas lugnt.

## Faktiskt
```
Unhandled exception. System.ArgumentNullException: Value cannot be null. (Parameter 'key')
   at System.Collections.Generic.Dictionary`2.FindValue(TKey key)
```

## Orsak
`Console.ReadLine()` returnerar `null` när det inte finns mer att läsa. `!` i `ContainsKey(wordToTranslate!)` tystar bara kompilatorns varning, och `null` skickas ändå vidare till dictionaryn.

## Var i koden
`Program.cs`, i huvudloopen.

## Åtgärdas i
UC7
