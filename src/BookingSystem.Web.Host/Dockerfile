FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BookingSystem.Web.Host/BookingSystem.Web.Host.csproj", "src/BookingSystem.Web.Host/"]
COPY ["src/BookingSystem.Web.Core/BookingSystem.Web.Core.csproj", "src/BookingSystem.Web.Core/"]
COPY ["src/BookingSystem.Application/BookingSystem.Application.csproj", "src/BookingSystem.Application/"]
COPY ["src/BookingSystem.Core/BookingSystem.Core.csproj", "src/BookingSystem.Core/"]
COPY ["src/BookingSystem.EntityFrameworkCore/BookingSystem.EntityFrameworkCore.csproj", "src/BookingSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/BookingSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BookingSystem.Web.Host", "src/BookingSystem.Web.Host"]
COPY ["src/BookingSystem.Web.Core", "src/BookingSystem.Web.Core"]
COPY ["src/BookingSystem.Application", "src/BookingSystem.Application"]
COPY ["src/BookingSystem.Core", "src/BookingSystem.Core"]
COPY ["src/BookingSystem.EntityFrameworkCore", "src/BookingSystem.EntityFrameworkCore"]
WORKDIR "/src/src/BookingSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BookingSystem.Web.Host.dll"]
