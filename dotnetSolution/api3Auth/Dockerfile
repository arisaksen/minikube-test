FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /source

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore "api3Auth.csproj" --disable-parallel
# Build and publish a release
RUN dotnet publish "api3Auth.csproj" -c release -o /app --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app ./

EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081

ENTRYPOINT ["dotnet", "api3Auth.dll"]
