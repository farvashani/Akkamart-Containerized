FROM microsoft/dotnet:2.2-sdk

COPY Gateway.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Gateway.dll", "Gateway.conf"] 
