FROM microsoft/dotnet:2.2-sdk

COPY Products.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Products.dll", "Products.conf"] 
