# kiri

Kiri, the URL shortener that slices your long links into bite-sized pieces. 

"Kiri" (切り) in Japanese can mean "slice", and that's exactly what this service does your URLs – trim them for easier sharing.

# Getting started

## Running locally with Docker

1. Navigate to the root directory of the project

2. Spin up the api and postgres container with docker-compose

```bash
docker compose up
```

Alternatively, add the `-d` flag to run the containers in the background.

```bash
docker compose up -d
```

### Cleaning up containers

```bash
docker compose down
```

## Running locally without Docker

- Pre-requisites
  - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - [PostgreSQL](https://www.postgresql.org/download/)

1. Kiri depends on Postgres for data storage. Ensure that you have a Postgres instance running locally with properties that match the `ConnectionString` value in your [appsettings.Local.json](https://github.com/umizu/kiri/blob/main/src/Kiri.Api/appsettings.Local.json) file.

2. Start the API by running the following command from the root directory of the project.

```bash
dotnet run --project src/Kiri.Api
```

# API Documentation

Ref -> http://localhost:9000/swagger/index.html

___

**ShortenURLRequest**

`POST` /api/shorten

```json
{
  "url": "https://genius.com/Rick-astley-never-gonna-give-you-up-lyrics"
}
```

**ShortenURLResponse**

```json
{
  "url": "http://kiri.ly/a1b2c3d4"
}
```
___

