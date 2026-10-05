# Use cases

Use cases för att göra glosprogrammet generiskt, så att språken bestäms av vilka ordlistor som finns i `wordlists/`. Ta dem i ordning, en i taget, och kör och testa varje steg innan nästa påbörjas.

| # | Use case | Beroenden |
|---|----------|-----------|
| 1 | [Läs språken från filnamnet](UC1-sprak-fran-filnamn.md) | – |
| 2 | [Läs in alla ordlistor i mappen](UC2-las-alla-ordlistor.md) | UC1 |
| 3 | [Visa vilka språkpar som finns](UC3-visa-sprakpar.md) | UC2 |
| 4 | [Välj språkpar](UC4-valj-sprakpar.md) | UC3 |
| 5 | [Byt språkpar under körning](UC5-byt-sprakpar.md) | UC4 |
| 6 | [Översätt åt båda hållen](UC6-oversatt-at-bada-hallen.md) | UC4 |
| 7 | [Hantera felaktiga filer och felaktig inmatning](UC7-felhantering.md) | UC2 |
| 8 | [Extrapolera översättningar via ett gemensamt språk](UC8-extrapolera-oversattningar.md) | UC6 |

UC1–UC4 gör programmet generiskt. UC5–UC8 är förbättringar ovanpå det.
