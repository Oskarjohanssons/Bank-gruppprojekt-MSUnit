# Bank Gruppprojekt - Enhetstester

## Affärskritiska delar och potentiella fel

### 1. Skapande av nya användare
-Användarnamnet är ogiltigt (för kort eller innehåller ogiltiga tecken).
-PIN-koden är ogiltig (inte exakt fyra siffror lång eller innehåller icke-numeriska tecken).
-Användarnamnet är inte unikt.
### 2. Radering av användarkonton
-Användaren som försöker radera kontot existerar inte.
-Kontot som ska raderas existerar inte.
-Kontot som ska raderas har ett saldo som inte är noll.
-dministratören som försöker radera kontot har inte tillräckliga behörigheter.
### 3. Hämtning och inställning av valutakurser
-Valutorna som anges existerar inte.
-Den nya växelkursen är ogiltig (t.ex. negativ eller noll).
-Uppdatering av växelkursen utförs inte korrekt.








