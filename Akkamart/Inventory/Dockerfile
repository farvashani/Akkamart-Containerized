FROM microsoft/dotnet:2.2-sdk

COPY Inventory.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Inventory.dll", "Inventory.conf"] 
