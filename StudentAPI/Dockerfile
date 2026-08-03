FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudentAPI/StudentAPI.csproj", "./StudentAPI/"]
RUN dotnet restore "./StudentAPI/StudentAPI.csproj"
COPY . .
WORKDIR "/src/StudentAPI"
RUN dotnet build "./StudentAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./StudentAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentAPI.dll"]
