# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Install EF Core tools and ASP.NET Code Generator globally
RUN dotnet tool install --global dotnet-ef --version 8.0.0
RUN dotnet tool install --global dotnet-aspnet-codegenerator --version 8.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy source code and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80 for the web application
EXPOSE 80
EXPOSE 443

# Set environment variable
ENV ASPNETCORE_URLS=http://+:80

# Run the application
ENTRYPOINT ["dotnet", "p1.dll"]
