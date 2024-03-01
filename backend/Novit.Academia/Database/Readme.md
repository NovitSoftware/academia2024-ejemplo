# Database

Aqui deben estar las clases relacionadas con la base de datos, DbContext, Migrations, etc

## Ef Core Cli

Se debe instalar (o actualizar en caso de ser necesario) **Entity Framework Core tools reference**
```
dotnet tool install --global dotnet-ef
```

## Migrations

Los siguientes comandos deben ejecutarse desde el Powershell o PMC (Package Manager Console). Men� Herramientas => NugetPackage Manager Console => Package Manager Console

Add una nueva migracion con nombre **InitialMigration**
```
dotnet ef migrations add MigracionInicial --project Novit.Academia --context AppDbContext --output-dir Database\Migrations
```

Para crear la base de datos de Sqlite
```
dotnet ef database update --project Novit.Academia
```
