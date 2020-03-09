#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster-arm64v8 AS build
WORKDIR /src
COPY ["BlazorApp/BlazorApp.csproj", "BlazorApp/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["PressureCore/PressureCore.csproj", "PressureCore/"]
RUN dotnet restore "BlazorApp/BlazorApp.csproj"
COPY . .
WORKDIR "/src/BlazorApp"
RUN dotnet build "BlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp.dll"]