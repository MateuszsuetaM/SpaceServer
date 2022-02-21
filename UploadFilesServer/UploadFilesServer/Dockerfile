FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
RUN mkdir Resources
#ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
ENTRYPOINT ["dotnet", "UploadFilesServer.dll"]