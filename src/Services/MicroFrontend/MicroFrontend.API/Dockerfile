#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/MicroFrontend/MicroFrontend.API/MicroFrontend.API.csproj", "Services/MicroFrontend/MicroFrontend.API/"]
RUN dotnet restore "Services/MicroFrontend/MicroFrontend.API/MicroFrontend.API.csproj"
COPY . .
WORKDIR "/src/Services/MicroFrontend/MicroFrontend.API"
RUN dotnet build "MicroFrontend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroFrontend.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroFrontend.API.dll"]