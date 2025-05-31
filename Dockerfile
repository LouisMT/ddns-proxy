FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

RUN apt-get update && \
    apt-get install -y clang zlib1g-dev

WORKDIR /app

COPY . .

RUN dotnet publish src/Core -c Release -o /build

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0

WORKDIR /app

COPY --from=build /build/Core ddns-proxy

ENTRYPOINT ["/app/ddns-proxy"]
