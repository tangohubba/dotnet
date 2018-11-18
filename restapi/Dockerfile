FROM  microsoft/dotnet:2.1-aspnetcore-runtime

WORKDIR '/app'

EXPOSE 80
COPY publish/ .
ENTRYPOINT ["dotnet", "restapi.dll"]