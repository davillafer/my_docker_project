FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

EXPOSE 9090

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WS.Proyecto.Mapa.WebAPI/WS.Proyecto.Mapa.WebAPI.csproj", "WS.Proyecto.Mapa.WebAPI/"]
RUN dotnet restore "WS.Proyecto.Mapa.WebAPI/WS.Proyecto.Mapa.WebAPI.csproj"
COPY . .
WORKDIR "/src/WS.Proyecto.Mapa.WebAPI"
RUN dotnet build "WS.Proyecto.Mapa.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WS.Proyecto.Mapa.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WS.Proyecto.Mapa.WebAPI.dll"]