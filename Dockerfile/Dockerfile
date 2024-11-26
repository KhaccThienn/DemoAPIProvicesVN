FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG http_proxy=http://10.26.2.55:8000
ARG https_proxy=http://10.26.2.55:8000
WORKDIR /src
COPY ["DemoAPIProvicesVN/DemoAPIProvicesVN.csproj", "DemoAPIProvicesVN/"]
RUN dotnet restore "DemoAPIProvicesVN/DemoAPIProvicesVN.csproj"

COPY . .
WORKDIR "/src/DemoAPIProvicesVN"
RUN dotnet build "DemoAPIProvicesVN.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoAPIProvicesVN.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoAPIProvicesVN.dll"]