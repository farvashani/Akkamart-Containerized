FROM microsoft/dotnet:2.2-sdk

COPY Messangers.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Messangers.dll", "Messangers.conf"] 
