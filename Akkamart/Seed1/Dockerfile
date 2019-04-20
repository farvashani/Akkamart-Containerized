FROM microsoft/dotnet:2.2-sdk

COPY Seed1.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Seed1.dll", "Seed1.conf"] 
