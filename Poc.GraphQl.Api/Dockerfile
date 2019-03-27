FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Poc.GraphQl.Api/Poc.GraphQl.Api.csproj", "Poc.GraphQl.Api/"]
RUN dotnet restore "Poc.GraphQl.Api/Poc.GraphQl.Api.csproj"
COPY . .
WORKDIR "/src/Poc.GraphQl.Api"
RUN dotnet build "Poc.GraphQl.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Poc.GraphQl.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Poc.GraphQl.Api.dll"]