FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
# COPY *.sln .
# COPY SoilParamsLibNET/*.csproj Colors.UnitTests/
COPY *.csproj .
RUN dotnet restore
COPY . .

# testing
# FROM build AS testing
# WORKDIR /src/Colors.API
# RUN dotnet build
# WORKDIR /src/Colors.UnitTests
# RUN dotnet test

# publish
FROM build AS publish
WORKDIR /src
RUN dotnet build
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
COPY --from=publish /src/publish/runtimes/linux-x64/native/*.so ./
# ENTRYPOINT ["dotnet", "Colors.API.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet SoilParamsAPI.dll
