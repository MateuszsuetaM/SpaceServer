# https://hub.docker.com/_/microsoft-dotnet

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
#EXPOSE 80
#EXPOSE 443
# copy csproj and restore as distinct layers
COPY *.sln .
COPY UploadFilesServer/*.csproj ./UploadFilesServer/
RUN dotnet restore

# copy everything else and build app
COPY UploadFilesServer/. ./UploadFilesServer/
WORKDIR /source/UploadFilesServer
RUN dotnet publish -c release -o /app #--no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
RUN mkdir Resources
#RUN ls
#VOLUME ["/app/Resources"]
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "UploadFilesServer.dll"]