FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudentAPI/StudentAPI.csproj", "StudentAPI/"]
RUN dotnet restore "StudentAPI/StudentAPI.csproj"
COPY . .
WORKDIR "/src/StudentAPI"
RUN dotnet publish "StudentAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "StudentAPI.dll"]
