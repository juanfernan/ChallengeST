# ChallengeStorey

Este proyecto es una Web API construida en .NET utilizando:

- .NET 8
- Entity Framework Core InMemory
- AutoMapper
- MediatR
- xUnit
- Moq
- FluentAssertions

##  Base de datos In-Memory con Seed automático

Al ejecutar la app, se carga una base de datos en memoria que incluye los datos del json que me proporcionaron,
esto lo hice para evitar tener que levantar una base de datos local y correr las migrations.

El seed se realiza automáticamente en `Program.cs`:

## Cómo ejecutar el proyecto


1. Clonar el repositorio:

```bash
git clone https://github.com/juanfernan/ChallengeST
cd ChallengeST
```

2. Restaurar paquetes:

```bash
dotnet restore
```

3. Ejecutar el proyecto:

```bash
dotnet run --project Api
```

4. Acceder a Swagger y probar el GET:

```
https://localhost:44366/swagger/index.html
```

---

## Endpoints

### `GET /categories`

Devuelve los datos que pasaron en el json
---



