# TiendaServicios

##Excecute migrations
###Api.Autor

- Generate c# Files and Tables

dotnet ef migrations add MigracionPostgresInicial --project TiendaServicios.Api.Autor
dotnet ef database update --project TiendaServicios.Api.Autor

dotnet ef migrations add MigracionSqlServerInicial --project TiendaServicios.Api.Libro
dotnet ef database update --project TiendaServicios.Api,Libro

dotnet ef migrations add MigracionMySqlInicial --project TiendaServicios.Api.CarritoCompra
dotnet ef database update --project TiendaServicios.Api.CarritoCompra
