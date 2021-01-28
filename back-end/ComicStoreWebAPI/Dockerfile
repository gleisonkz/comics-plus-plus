#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ComicStoreWebAPI/ComicStore.Application.csproj", "ComicStoreWebAPI/"]
COPY ["ComicStore.Service/ComicStore.Service.csproj", "ComicStore.Service/"]
COPY ["ComicStore.Domain/ComicStore.Domain.csproj", "ComicStore.Domain/"]
COPY ["Comic.Shared/ComicStore.Shared.csproj", "Comic.Shared/"]
COPY ["ComicStore.Infra.BaseRepository/ComicStore.Infra.BaseRepository.csproj", "ComicStore.Infra.BaseRepository/"]
COPY ["ComicStore.Infra.Security/ComicStore.Infra.Security.csproj", "ComicStore.Infra.Security/"]
COPY ["ComicStore.Infra.EFRepository/ComicStore.Infra.EFRepository.csproj", "ComicStore.Infra.EFRepository/"]
RUN dotnet restore "ComicStoreWebAPI/ComicStore.Application.csproj"
COPY . .
WORKDIR "/src/ComicStoreWebAPI"
RUN dotnet build "ComicStore.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComicStore.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ComicStore.Application.dll"]