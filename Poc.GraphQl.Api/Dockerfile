FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY Poc.GraphQl.Api/Poc.GraphQl.Api.csproj Poc.GraphQl.Api/
RUN dotnet restore Poc.GraphQl.Api/Poc.GraphQl.Api.csproj
COPY . .
WORKDIR /src/Poc.GraphQl.Api
RUN dotnet build Poc.GraphQl.Api.csproj -c Release -o /app

#RUN dotnet ef migrations add InitialCreate
#RUN dotnet ef migrations script -o /migrations/init.sql

FROM build AS publish
RUN dotnet publish Poc.GraphQl.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "Poc.GraphQl.Api.dll"]
