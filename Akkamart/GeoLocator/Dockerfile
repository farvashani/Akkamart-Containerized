FROM microsoft/dotnet:2.2-sdk

COPY GeoLocator.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "GeoLocator.dll", "GeoLocator.conf"] 
