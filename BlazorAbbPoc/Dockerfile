FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Server/BlazorAbbPoc.Server.csproj", "Server/"]
COPY ["Client/BlazorAbbPoc.Client.csproj", "Client/"]
COPY ["Shared/BlazorAbbPoc.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/BlazorAbbPoc.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "BlazorAbbPoc.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorAbbPoc.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorAbbPoc.Server.dll"]
