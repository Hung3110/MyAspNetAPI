# Sử dụng .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyAspNetAPI.csproj", "./"]
RUN dotnet restore "MyAspNetAPI.csproj"

COPY . .
RUN dotnet build "MyAspNetAPI.csproj" -c Release -o /app/build

# Publish ứng dụng
FROM build AS publish
RUN dotnet publish "MyAspNetAPI.csproj" -c Release -o /app/publish

# Chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetAPI.dll"]
