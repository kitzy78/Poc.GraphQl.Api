FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Poc.GraphQl.Api.csproj", "./"]
RUN dotnet restore "Poc.GraphQl.Api.csproj"
COPY . .
RUN dotnet build "Poc.GraphQl.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Poc.GraphQl.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Poc.GraphQl.Api.dll"]