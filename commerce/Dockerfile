# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source files and build the application
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the ASP.NET Core runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /out .

# Expose the port your app runs on (default 5000 for ASP.NET Core)
EXPOSE 5000

# Define the entry point for the container
ENTRYPOINT ["dotnet", "YourAppName.dll"]
# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source files and build the application
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the ASP.NET Core runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /out .

# Expose the port your app runs on (default 5000 for ASP.NET Core)
EXPOSE 5000

# Define the entry point for the container
ENTRYPOINT ["dotnet", "YourAppName.dll"]
