FROM microsoft/dotnet:2.2-sdk

COPY Credentials.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Credentials.dll", "Credentials.conf"] 
