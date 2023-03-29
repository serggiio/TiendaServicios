# TiendaServicios

## Excecute migrations

- Docker databases
1. Create docker network
docker network create microservicenet

2. Postgres
docker run --name postgres-db -e POSTGRES_PASSWORD=postgres -d -p 5432:5432 postgres:latest
// Create database -> docker exec -it postgres-db bash

dotnet ef migrations add MigracionPostgresInicial --project TiendaServicios.Api.Autor
dotnet ef database update --project TiendaServicios.Api.Autor

//Add container to network
docker network connect microservicenet posgres-db

3. Sql Server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=sqlServer" -p 1433:1433 -d mcr.microsoft.com/mssql/server

//Add container to network
docker network connect microservicenet upbeat_robinson

dotnet ef migrations add MigracionSqlServerInicial --project TiendaServicios.Api.Libro
dotnet ef database update --project TiendaServicios.Api.Libro

4. MySql



dotnet ef migrations add MigracionMySqlInicial --project TiendaServicios.Api.CarritoCompra
dotnet ef database update --project TiendaServicios.Api.CarritoCompra
