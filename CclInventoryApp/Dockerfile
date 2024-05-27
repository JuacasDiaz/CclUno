# Utilizar una imagen base de .NET para la construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar los archivos de proyecto y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Utilizar una imagen base de .NET para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "CclInventoryApp.dll"]
