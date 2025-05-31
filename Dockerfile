FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

RUN apk add clang build-base zlib-dev

WORKDIR /app

COPY . .

RUN dotnet publish src/Core -c Release -o /build

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0-alpine

WORKDIR /app

COPY --from=build /build/Core ddns-proxy

ENTRYPOINT ["/app/ddns-proxy"]
