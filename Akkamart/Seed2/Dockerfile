FROM microsoft/dotnet:2.2-sdk

COPY Seed2.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Seed2.dll", "Seed2.conf"] 
