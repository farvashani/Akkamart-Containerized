FROM microsoft/dotnet:2.2-sdk

COPY Catalogs.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Catalogs.dll", "Catalogs.conf"] 
