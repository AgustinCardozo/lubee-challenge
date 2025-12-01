# lubee-challenge

Este proyecto es una solución para un sistema de gestión de publicaciones correspondiente al challenge de [lubee](https://lubee.com.ar/). A continuación podrán ver una [demo](https://youtu.be/Edw2enFmXaY) del proyecto.

## Resumen (backend + frontend)

Backend (Publicacion.Api):

- ASP.NET Core (.NET 9) con EF Core y PostgreSQL.
- Endpoints: /lubee-publicacion/api/v1/publicaciones (CRUD) y /lubee-publicacion/api/v1/imagenes/{publicationId}.
- PathBase configurado: /lubee-publicacion (URL local: https://localhost:5000/lubee-publicacion).

Frontend (publicacion-frontend):

- Vue 3 + TypeScript, Vite, Bootstrap CSS.
- Componentes: listado, formulario y modal de detalle; imágenes solicitadas por publicación.

Ejecución rápida:

1) (Opcional) Levantar Postgres en Docker en el puerto 5433 (ver backend/README.md).
2) Backend: cd backend/publicacion-api/src/Publicacion.Api && dotnet run
3) Frontend: cd frontend/publicacion-frontend && npm install && npm run dev
