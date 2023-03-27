# LiftApp-migrations
- Část projektu tvořeného v rámci diplomové práce, který je určen pro migraci datového modelu do relačního DBMS PostgreSQL.
- Před prvním spuštěním aplikace umístěné v repositáři LiftApp je nutné migraci provést (viz. Provedení migrace)


## Provedení migrace
### Prerekvizity
- Nainstalovaný **PostgreSQL** (testováno na verzi **PostgreSQL 15.1, compiled by Visual C++ build 1914, 64-bit** - pro ověření slouží SQL dotaz `SELECT VERSION();`)
- Nainstalovaný **.NET 6**
### Postup
1. Otevřít solution `src\LiftApp\LiftApp-migrations.sln`
2. V konfiguračním souboru `src\LiftApp\appsettings.json` upravit connection string `ConnectionStrings.DefaultConnection` (hodnoty `Username` a `Password` - přihlašovací údaje k PostgreSQL zadávané při instalaci).
3. V podokně Developer PowerShell aplikace Visual Studio zadat příkazy:
    1. Přesun do adresáře projektu LiftApp.Dal - `cd C:\source\repos\LiftApp-migrations\src\LiftApp.Dal`
    2. `dotnet ef migrations add NazevMigrace --startup-project ../LiftApp/LiftApp.csproj`
    3. `dotnet ef database update --startup-project ../LiftApp/LiftApp.csproj`
4. **Po spuštění těchto příkazů by měla být vytvořena databáze se vzorovými daty a je možné spustit aplikaci umístěnou v repositáři LiftApp podle návodu v README.md.**
5. Pro potřebu opakovaného provedení migrace je nutné:
    1. Odstranit databázi v PostgreSQL (`DROP DATABASE "NázevDatabáze";`)
    2. Odstranit složku `src\LiftApp.Dal\Migrations`
    3. Dále již pokračovat krokem 2