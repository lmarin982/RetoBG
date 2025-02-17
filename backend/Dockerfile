# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/reto_bg.Api/reto_bg.Api.csproj", "src/reto_bg.Api/"]
COPY ["src/reto_bg.Application/reto_bg.Application.csproj", "src/reto_bg.Application/"]
COPY ["src/reto_bg.Domain/reto_bg.Domain.csproj", "src/reto_bg.Domain/"]
COPY ["src/reto_bg.Infraestructure/reto_bg.Infraestructure.csproj", "src/reto_bg.Infraestructure/"]
RUN dotnet restore "src/reto_bg.Api/reto_bg.Api.csproj"
COPY . .
WORKDIR "/src/src/reto_bg.Api"
RUN dotnet build "reto_bg.Api.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "reto_bg.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV LANG=es_ES.UTF-8

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "reto_bg.Api.dll"]