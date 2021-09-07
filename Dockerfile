FROM mcr.microsoft.com/dotnet/sdk:5.0

COPY bin/Debug/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "NetCore.Docker.dll"]

ENV DOTNET_EnableDiagnostics=0
ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust