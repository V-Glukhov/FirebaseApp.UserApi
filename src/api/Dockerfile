#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/api/UserApi.csproj", "src/api/"]
COPY ["src/DAL/UserApi.DAL.Repository.Implementation/UserApi.DAL.Repository.Implementation.csproj", "src/DAL/UserApi.DAL.Repository.Implementation/"]
COPY ["src/DAL/UserApi.DAL.Repository.Abstraction/UserApi.DAL.Repository.Abstraction.csproj", "src/DAL/UserApi.DAL.Repository.Abstraction/"]
COPY ["src/DAL/UserApi.DAL.Models/UserApi.DAL.Models.csproj", "src/DAL/UserApi.DAL.Models/"]
COPY ["src/BL/UserApi.BL.UserService/UserApi.BL.UserService.csproj", "src/BL/UserApi.BL.UserService/"]
COPY ["src/BL/UserApi.BL.UserServiceContracts/UserApi.BL.Contracts.csproj", "src/BL/UserApi.BL.UserServiceContracts/"]
RUN dotnet restore "src/api/UserApi.csproj"
COPY . .
WORKDIR "/src/src/api"
RUN dotnet build "UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserApi.dll"]