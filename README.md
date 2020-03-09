# Hi David, Yannay, Quim, Guille!! 

### Development environment installation
  - .Net Core SDK: 
    > https://dotnet.microsoft.com/download/dotnet-core/3.1
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
    Install EF Core Tools:
    * dotnet tool install --global dotnet-ef --version 3.1.2
  - Install Postman:
    * https://www.postman.com/downloads/

  - Install Redis:
    * https://drive.google.com/open?id=1GnMmd35q9qv21rAcz-6ecqnPX18Hq4ld
  - Install Postman:
    * https://www.postman.com/
  - Install Redis:
	* https://github.com/MicrosoftArchive/redis/releases/download/win-3.0.504/Redis-x64-3.0.504.msi
  - Install Redily:
    * https://www.redily.app/download/win
	go to File - New Connection. We put the name of the connection and leave the data that is 127.0.0.1 and port 6379, which are what Redis uses. Press "Test Connection" to see if it works and then to "Add".
	
### The project
For run the project
```sh
dotnet run
```

crear carpeta en Pizzeria/src/ImageServer

npm init

npm install express --save

npm install body-parser --save

npm install --save multer


Comandos para migración;
ejecutar en carpeta src/pizzeria
dotnet ef migrations add InitialCreate --startup-project ../pizzeria --project ../infraestructure

dotnet ef database update
