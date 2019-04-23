FROM microsoft/dotnet:2.2-sdk

COPY Accounting.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Accounting.dll", "Accounting.conf"] 
