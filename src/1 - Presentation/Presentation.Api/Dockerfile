#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["1 - Presentation/Presentation.Api/Presentation.Api.csproj", "1 - Presentation/Presentation.Api/"]
RUN dotnet restore "1 - Presentation/Presentation.Api/Presentation.Api.csproj"
COPY . .
WORKDIR "/src/1 - Presentation/Presentation.Api"
RUN dotnet build "Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.Api.dll"]