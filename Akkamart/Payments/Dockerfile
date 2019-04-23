FROM microsoft/dotnet:2.2-sdk

COPY Payments.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Payments.dll", "Payments.conf"] 
