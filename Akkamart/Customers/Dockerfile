FROM microsoft/dotnet:2.2-sdk

COPY Customers.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Customers.dll", "Customers.conf"] 
