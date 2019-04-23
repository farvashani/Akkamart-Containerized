FROM microsoft/dotnet:2.2-sdk

COPY Marketing.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Marketing.dll", "Marketing.conf"] 
