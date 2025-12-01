# Publicacion API (backend)

Pequeña API REST (ASP.NET Core, .NET 9) para administrar publicaciones.

## Requisitos

- .NET 9 SDK
- PostgreSQL (local o Docker)

## Ejecutar en desarrollo

1. Levantar Postgres con Docker:

```powershell
cd .\backend
docker-compose up -d
```

2. Ajustar `appsettings.Development.json` o exportar la variable de entorno `ConnectionStrings__DefaultConnection`.
   Ejemplo de cadena: `Host=localhost;Port=5433;Database=lubee_publicaciones_db;Username=postgres;Password=postgres`

3. Ejecutar la API:

```powershell
cd .\backend\publicacion-api\src\Publicacion.Api
dotnet run
```

## Principales endpoints

La API corre en `https://localhost:5000/lubee-publicacion` (PathBase configurado). Swagger disponible en `/swagger` en Development.

- GET  /lubee-publicacion/api/v1/publicaciones
- GET  /lubee-publicacion/api/v1/publicaciones/{id}
- POST /lubee-publicacion/api/v1/publicaciones
- PUT  /lubee-publicacion/api/v1/publicaciones/{id}
- DELETE /lubee-publicacion/api/v1/publicaciones/{id}
- GET  /lubee-publicacion/api/v1/imagenes/{publicationId}

## Migraciones

Las migraciones EF Core están en `Publicacion.Infrastructure/Migrations`.
Aplicar manualmente:

```powershell
dotnet ef database update --project Publicacion.Infrastructure --startup-project Publicacion.Api
```
