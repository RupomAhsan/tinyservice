FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /publish
COPY . .
RUN dotnet publish src/TinyService -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish/out .
ENV ASPNETCORE_ENVIRONMENT kubernetes
ENV ASPNETCORE_URLS http://*:3000
ENTRYPOINT dotnet TinyService.dll