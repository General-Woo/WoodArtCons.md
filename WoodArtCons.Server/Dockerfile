# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY WoodArtCons.sln ./

# Copiază toate fișierele .csproj necesare pentru dotnet restore
COPY WoodArtCons.Server/WoodArtCons.Server.csproj WoodArtCons.Server/
COPY WoodArtCons.Shared/WoodArtCons.Shared.csproj WoodArtCons.Shared/
COPY WoodArtCons/WoodArtCons.csproj WoodArtCons/

RUN dotnet restore

# Copiază restul fișierelor sursă
COPY . .
WORKDIR /src/WoodArtCons.Server
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001
ENTRYPOINT ["dotnet", "WoodArtCons.Server.dll"]
