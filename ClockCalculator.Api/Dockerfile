FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 5276 (HTTP only)
EXPOSE 5276

# Set ASP.NET Core to listen on HTTP only and disable HTTPS redirection
ENV ASPNETCORE_URLS=http://+:5276
ENV ASPNETCORE_HTTP_PORTS=5276

ENTRYPOINT ["dotnet", "ClockCalculator.Api.dll"]
