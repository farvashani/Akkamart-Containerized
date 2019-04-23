FROM microsoft/dotnet:2.2-sdk

COPY Points.conf /opt
COPY bin/Debug/netcoreapp2.2/publish /opt

WORKDIR /opt

ENTRYPOINT ["dotnet", "Points.dll", "Points.conf"] 
