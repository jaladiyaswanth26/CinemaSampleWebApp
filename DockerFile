# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Working directory inside the container
WORKDIR /app

# Copy the published application
COPY publish/ .

# ASP.NET Core listens on port 8080
EXPOSE 8080

# Start the application
ENTRYPOINT ["dotnet", "SampleWebApp.dll"]
