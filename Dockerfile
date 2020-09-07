FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY *.csproj /src
RUN dotnet restore
COPY . .

FROM build AS publish
WORKDIR /src
RUN ls
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet projeto-api.dll

#93d87717-e022-424f-980e-8b46b10f1821