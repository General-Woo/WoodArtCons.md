# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY WoodArtCons.sln ./
COPY WoodArtCons/WoodArtCons.csproj WoodArtCons/
COPY WoodArtCons.Server/WoodArtCons.Server.csproj WoodArtCons.Server/
COPY WoodArtCons.Shared/WoodArtCons.Shared.csproj WoodArtCons.Shared/
RUN dotnet restore
COPY . .
WORKDIR /src/WoodArtCons
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "WoodArtCons.dll"] 
