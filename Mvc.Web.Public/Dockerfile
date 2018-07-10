FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Mvc.Web.Public/Mvc.Web.Public.csproj Mvc.Web.Public/
RUN dotnet restore Mvc.Web.Public/Mvc.Web.Public.csproj
COPY . .
WORKDIR /src/Mvc.Web.Public
RUN dotnet build Mvc.Web.Public.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Mvc.Web.Public.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mvc.Web.Public.dll"]
