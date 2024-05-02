FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs icu-data-full
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["testeLogico2.csproj", "./"]
RUN dotnet restore "testeLogico2.csproj"
COPY . .
WORKDIR "/src/."

RUN dotnet build "testeLogico2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testeLogico2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testeLogico2.dll"]