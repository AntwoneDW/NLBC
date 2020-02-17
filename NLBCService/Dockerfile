#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NLBCService/NLBCService.csproj", "NLBCService/"]
RUN dotnet restore "NLBCService/NLBCService.csproj"
COPY . .
WORKDIR "/src/NLBCService"
RUN dotnet build "NLBCService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NLBCService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NLBCService.dll"]