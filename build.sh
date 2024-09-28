rm bin/ -rf && mkdir bin
dotnet publish -c Release
mv src/Hunter.BookStore.DbMigrator/bin/Release/net8.0/publish/ bin/DbMigrator -f
mv src/Hunter.BookStore.HttpApi.Host/bin/Release/net8.0/publish/ bin/Host
mv src/Hunter.BookStore.Blazor/bin/Release/net8.0/publish/ bin/Blazor
