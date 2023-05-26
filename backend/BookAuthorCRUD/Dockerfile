#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookAuthorCRUD/BookAuthorCRUD.API.csproj", "BookAuthorCRUD/"]
COPY ["BookAuthorCRUD.Application/BookAuthorCRUD.Application.csproj", "BookAuthorCRUD.Application/"]
COPY ["BookAuthorCRUD.Contract/BookAuthorCRUD.Contract.csproj", "BookAuthorCRUD.Contract/"]
COPY ["BookAuthorCRUD.Domain/BookAuthorCRUD.Domain.csproj", "BookAuthorCRUD.Domain/"]
COPY ["BookAuthorCRUD.Infrastructure.Persistence/BookAuthorCRUD.Infrastructure.Persistence.csproj", "BookAuthorCRUD.Infrastructure.Persistence/"]
COPY ["BookAuthorCRUD.Test/BookAuthorCRUD.Test.csproj", "BookAuthorCRUD.Test/"]
RUN dotnet restore "BookAuthorCRUD/BookAuthorCRUD.API.csproj"
COPY . .
WORKDIR "/src/BookAuthorCRUD"
RUN dotnet build "BookAuthorCRUD.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookAuthorCRUD.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookAuthorCRUD.API.dll"]