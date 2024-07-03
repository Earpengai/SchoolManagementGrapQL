# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SchoolManagementGraphQL.csproj", "./"]
RUN dotnet restore "./SchoolManagementGraphQL.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SchoolManagementGraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolManagementGraphQL.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolManagementGraphQL.dll"]
