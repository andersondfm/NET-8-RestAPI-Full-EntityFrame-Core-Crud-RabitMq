#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ANDERSONDFM.API/ANDERSONDFM.API.csproj", "src/ANDERSONDFM.API/"]
COPY ["src/ANDERSONDFM.Aplicacao/ANDERSONDFM.Aplicacao.csproj", "src/ANDERSONDFM.Aplicacao/"]
COPY ["src/ANDERSONDFM.Compartilhado/ANDERSONDFM.Compartilhado.csproj", "src/ANDERSONDFM.Compartilhado/"]
COPY ["src/ANDERSONDFM.Dominio/ANDERSONDFM.Dominio.csproj", "src/ANDERSONDFM.Dominio/"]
COPY ["src/ANDERSONDFM.Infra/ANDERSONDFM.Infra.csproj", "src/ANDERSONDFM.Infra/"]
COPY ["src/ANDERSONDFM.Integracao/ANDERSONDFM.Integracao.csproj", "src/ANDERSONDFM.Integracao/"]
COPY ["src/ANDERSONDFM.Infra.IoC/ANDERSONDFM.Infra.IoC.csproj", "src/ANDERSONDFM.Infra.IoC/"]
RUN dotnet restore "src/ANDERSONDFM.API/ANDERSONDFM.API.csproj"
COPY . .
WORKDIR "/src/src/ANDERSONDFM.API"
RUN dotnet build "ANDERSONDFM.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ANDERSONDFM.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ANDERSONDFM.API.dll"]