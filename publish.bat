cd  mvc
dotnet publish -o publish

#replace dockeruser1212 with your own docker hub id 
docker build -t dockeruser1212/mvc .
docker push dockeruser1212/mvc

cd ..\restapi
dotnet publish -o publish

#replace dockeruser1212 with your own docker hub id 
docker build -t dockeruser1212/restapi .
docker push dockeruser1212/restapi

cd ..
