#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["1 - Presentation/Presentation.WorkerService/Presentation.WorkerService.csproj", "1 - Presentation/Presentation.WorkerService/"]
RUN dotnet restore "1 - Presentation/Presentation.WorkerService/Presentation.WorkerService.csproj"
COPY . .
WORKDIR "/src/1 - Presentation/Presentation.WorkerService"
RUN dotnet build "Presentation.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.WorkerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.WorkerService.dll"]