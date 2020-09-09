#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CarRentalCompany.Microservices.IamMicroservice.STS.Identity/CarRentalCompany.Microservices.IamMicroservice.STS.Identity.csproj", "src/CarRentalCompany.Microservices.IamMicroservice.STS.Identity/"]
COPY ["src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.Shared/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.Shared.csproj", "src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.Shared/"]
COPY ["src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer.csproj", "src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/"]
COPY ["src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL.csproj", "src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/CarRentalCompany.Microservices.IamMicroservice.Shared/CarRentalCompany.Microservices.IamMicroservice.Shared.csproj", "src/CarRentalCompany.Microservices.IamMicroservice.Shared/"]
COPY ["src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.MySql/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.MySql.csproj", "src/CarRentalCompany.Microservices.IamMicroservice.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/CarRentalCompany.Microservices.IamMicroservice.STS.Identity/CarRentalCompany.Microservices.IamMicroservice.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/CarRentalCompany.Microservices.IamMicroservice.STS.Identity"
RUN dotnet build "CarRentalCompany.Microservices.IamMicroservice.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalCompany.Microservices.IamMicroservice.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CarRentalCompany.Microservices.IamMicroservice.STS.Identity.dll"]