FROM microsoft/dotnet:2.2-sdk

COPY Memberships.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Memberships.dll", "Memberships.conf"] 
