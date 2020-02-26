# Hi David, Yannay, Quim, Guille!! 

### Development environment installation
  - .Net Core SDK: 
    > https://dotnet.microsoft.com/download

  - Visual Studio Code 2010 with C# and Java plugin
    * https://visualstudio.microsoft.com/es/downloads
    * https://marketplace.visualstudio.com/items?itemName=vscjava.vscode-java-pack
    * https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp
    * https://marketplace.visualstudio.com/items?itemName=ms-mssql.mssql
    * https://marketplace.visualstudio.com/items?itemName=vitorsalgado.vscode-redis
  
  - Install Entity Framework by the following steps:
    * https://docs.microsoft.com/es-es/ef/core/get-started/install/
    * dotnet add package EntityFramework --version 6.4.0
  - Install Entity Framework Core:
    * dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  
  - Install Postman:
    * https://www.postman.com/downloads/

  - Install Redis:
    * https://drive.google.com/open?id=1GnMmd35q9qv21rAcz-6ecqnPX18Hq4ld
  - Install Postman:
    * https://www.postman.com/
  - Install Redis:
	* https://github.com/microsoftarchive/redis/releases/download/win-3.0.504/Redis-x64-3.0.504.msi* https://github-production-release-asset-2e65be.s3.amazonaws.com/3402186/124bda0a-3fa5-11e6-8c4a-803581ed704c?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIWNJYAX4CSVEH53A%2F20200226%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20200226T095458Z&X-Amz-Expires=300&X-Amz-Signature=c62e8d4a724b3704f3ebd77440953823dbd03853fee64e6f696bb3d43cf9bab6&X-Amz-SignedHeaders=host&actor_id=16489540&response-content-disposition=attachment%3B%20filename%3DRedis-x64-3.0.504.msi&response-content-type=application%2Foctet-stream
  - Install Redily:
    * https://www.redily.app/download/win
	go to File - New Connection. We put the name of the connection and leave the data that is 127.0.0.1 and port 6379, which are what Redis uses. Press "Test Connection" to see if it works and then to "Add".
	
### The project
For run the project
```sh
dotnet run
```

For testing go to the file Tests and run bats
