#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Test API/Test API.csproj", "Test API/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Entities/Entities (modele de donnes).csproj", "Entities/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Modele_de_domaine/Modele_de_domaine.csproj", "Modele_de_domaine/"]
COPY ["Profilee/Profiles.csproj", "Profilee/"]
RUN dotnet restore "Test API/Test API.csproj"
COPY . .
WORKDIR "/src/Test API"
RUN dotnet build "Test API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test API.dll"]