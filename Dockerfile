# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source/DotStat.Api

# copy csproj and restore as distinct layers
COPY ./DotStat.Api/*.sln .
COPY ./DotStat.Api/DotStat.Api.Rest/*.csproj ./DotStat.Api.Rest/
COPY ./DotStat.Api/DotStat.Api.Application/*.csproj ./DotStat.Api.Application/
COPY ./DotStat.Api/DotStat.Api.Contracts/*.csproj ./DotStat.Api.Contracts/
COPY ./DotStat.Api/DotStat.Api.Domain/*.csproj ./DotStat.Api.Domain/
COPY ./DotStat.Api/DotStat.Api.Infrastructure/*.csproj ./DotStat.Api.Infrastructure/

RUN dotnet restore

# copy everything else and build app
COPY ./DotStat.Api ./
WORKDIR /source/DotStat.Api/DotStat.Api.Rest
RUN dotnet publish -c Release -o /app
COPY ./DotStat.Api/DotStat.Api.Rest/StaticFiles /app/StaticFiles

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

RUN apt-get update
RUN apt-get --yes install curl

ENV ASPNETCORE_URLS=http://+:5293
HEALTHCHECK CMD curl --fail http://localhost:5293/healthz || exit

EXPOSE 5293

ENTRYPOINT ["dotnet", "DotStat.Api.Rest.dll"]