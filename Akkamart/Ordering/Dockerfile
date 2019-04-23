FROM microsoft/dotnet:2.2-sdk

COPY Ordering.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Ordering.dll", "Ordering.conf"] 
