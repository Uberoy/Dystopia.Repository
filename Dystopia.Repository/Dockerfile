# Stage 1: Build all dependencies
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files with correct relative paths
COPY ["Dystopia.Repository/Dystopia.Repository/Dystopia.Repository.csproj", "Dystopia.Repository/Dystopia.Repository/"]

# Restore dependencies
RUN dotnet restore "Dystopia.Repository/Dystopia.Repository/Dystopia.Repository.csproj"

# Copy the full solution
COPY . .

# Build all projects
RUN dotnet build "Dystopia.Repository/Dystopia.Repository/Dystopia.Repository.csproj" -c Release

# Stage 3: Publish Dystopia
FROM build AS publish
WORKDIR /src/Dystopia.Repository
RUN dotnet publish "Dystopia.Repository/Dystopia.Repository.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final runtime image for Dystopia
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Dystopia.Repository.dll"]
