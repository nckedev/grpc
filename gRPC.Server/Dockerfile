FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG PASSWORD_ENV_SEEDED

RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p ${PASSWORD_ENV_SEEDED}
WORKDIR /src
COPY ["gRPC.Server/gRPC.Server.csproj", "gRPC.Server/"]
COPY ["gRPC.Shared/gRPC.Shared.csproj", "gRPC.Shared/"]
RUN dotnet restore "gRPC.Server/gRPC.Server.csproj"
COPY . .
WORKDIR "/src/gRPC.Server"

#generate the cert, define the path to store it and password to use

RUN dotnet build "gRPC.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gRPC.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /https/* /https/
ENTRYPOINT ["dotnet", "gRPC.Server.dll"]
