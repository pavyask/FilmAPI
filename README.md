# FilmAPI
Simple Films WEB API using ASP .NET CORE


# How to run the Web API
1. SQL Express must be installed

2. Open project in Microsoft Visual Studio 2022 (project was developed in it, so instruction will be for it)

3. Download all packages from project file

4. In the Package Manager Console (or in the Powershell inside project folder) enter command:
        dotnet ef database update
   After that, the empty database named "filmdb" must be created

5. Now you can start the program, which will open Swagger API documentation in your browser on this addres https://localhost:7259/swagger/index.html

(6). For dropping database enter command inside the project folder:
        dotnet ef database drop -f
