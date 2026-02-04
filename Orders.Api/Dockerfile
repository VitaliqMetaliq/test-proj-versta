FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY Orders.Api.sln .

COPY Orders.Api.Main/Orders.Api.Main.csproj Orders.Api.Main/
COPY Orders.Api.Application/Orders.Api.Application.csproj Orders.Api.Application/
COPY Orders.Api.Domain/Orders.Api.Domain.csproj Orders.Api.Domain/
COPY Orders.Api.Infrastructure/Orders.Api.Infrastructure.csproj Orders.Api.Infrastructure/

RUN dotnet restore Orders.Api.sln

COPY . .

WORKDIR /src/Orders.Api.Main
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "Orders.Api.Main.dll"]