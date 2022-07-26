#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApollosLibrary.IDP/ApollosLibrary.IDP.csproj", "ApollosLibrary.IDP/"]
COPY ["ApollosLibrary.IDP.Infrastructure/ApollosLibrary.IDP.Infrastructure.csproj", "ApollosLibrary.IDP.Infrastructure/"]
COPY ["ApollosLibrary.IDP.Application/ApollosLibrary.IDP.Application.csproj", "ApollosLibrary.IDP.Application/"]
COPY ["ApollosLibrary.IDP.UnitOfWork.Contracts/ApollosLibrary.IDP.UnitOfWork.Contracts.csproj", "ApollosLibrary.IDP.UnitOfWork.Contracts/"]
COPY ["ApollosLibrary.IDP.Datalayer.Contracts/ApollosLibrary.IDP.DataLayer.Contracts.csproj", "ApollosLibrary.IDP.Datalayer.Contracts/"]
COPY ["ApollosLibrary.IDP.Domain/ApollosLibrary.IDP.Domain.csproj", "ApollosLibrary.IDP.Domain/"]
COPY ["ApollosLibrary.IDP.UnitOfWork/ApollosLibrary.IDP.UnitOfWork.csproj", "ApollosLibrary.IDP.UnitOfWork/"]
COPY ["ApollosLibrary.IDP.DataLayer/ApollosLibrary.IDP.DataLayer.csproj", "ApollosLibrary.IDP.DataLayer/"]
RUN dotnet restore "ApollosLibrary.IDP/ApollosLibrary.IDP.csproj"
COPY . .
WORKDIR "/src/ApollosLibrary.IDP"
RUN dotnet build "ApollosLibrary.IDP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApollosLibrary.IDP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApollosLibrary.IDP.dll"]