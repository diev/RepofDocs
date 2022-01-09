#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Rosd/Rosd.csproj", "Rosd/"]
RUN dotnet restore "Rosd/Rosd.csproj"
COPY . .
WORKDIR "/src/Rosd"
RUN dotnet tool install --global dotnet-ef
#RUN dotnet ef migrations add <migration name>
#RUN dotnet ef database update
RUN dotnet build "Rosd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rosd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rosd.dll"]