# 1. Sử dụng image .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# 2. Sử dụng image .NET SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 3. Copy file dự án và khôi phục dependencies
COPY ["Ktra90phut.csproj", "./"]
RUN dotnet restore "Ktra90phut.csproj"

# 4. Copy toàn bộ source code
COPY . .

# 5. Build ứng dụng
RUN dotnet build "Ktra90phut.csproj" -c Release -o /app/build

# 6. Publish ứng dụng
FROM build AS publish
RUN dotnet publish "Ktra90phut.csproj" -c Release -o /app/publish

# 7. Runtime stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Ktra90phut.dll"]
