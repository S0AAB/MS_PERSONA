# Usa la imagen base de Windows con .NET Framework 4.8 SDK
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia la solución desde una carpeta anterior (usa `../`)
COPY ../MS_PERSONA.sln .
COPY ../MS_PERSONA/ MS_PERSONA/

# Restaura los paquetes NuGet
RUN nuget restore MS_PERSONA.sln

# Compila la aplicación
RUN msbuild MS_PERSONA.sln /p:Configuration=Release /p:OutputPath=./publish

# Usa la imagen de runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
WORKDIR /inetpub/wwwroot

# Copia la aplicación compilada desde la etapa de compilación
COPY --from=build /app/publish .

# Expone el puerto 80
EXPOSE 80
