FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 as build
WORKDIR /temp/PxWeb
COPY . .
RUN nuget restore
RUN msbuild /p:Configuration=Release PXWeb/PXWeb.csproj /p:DeployOnBuild=true /p:PublishProfile=filesystem.pubxml

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019
WORKDIR /inetpub/wwwroot
COPY --from=build /temp/build/. ./
