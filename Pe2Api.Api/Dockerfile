#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pe2.Api/Pe2Api.Api.csproj", "Pe2.Api/"]
COPY ["Pe2.Infra/Pe2Api.Infra.csproj", "Pe2.Infra/"]
COPY ["Pe2Api.Domain/Pe2Api.Domain.csproj", "Pe2Api.Domain/"]
COPY ["Pe2Api.Extensions/Pe2Api.Extensions.csproj", "Pe2Api.Extensions/"]
RUN dotnet restore "Pe2.Api/Pe2Api.Api.csproj"
COPY . .
WORKDIR "/src/Pe2.Api"
RUN dotnet build "Pe2Api.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pe2Api.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pe2Api.Api.dll"]