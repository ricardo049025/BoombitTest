# BoombitTest

El proyecto contiene un proyecto para la parte del frontend (Jquery y un proyecto para la parte del backend (.net core 6.0.10).

El proyecto jquery se encuentra ubicado en la carpeta de frontend,

El proyecto en .net core esta haciendo uso de entityframework para la conexion de la base de datos y la arquitectura Domain Driven Design. Primeramente tiene que modificarse el app.setting que se encuentra ubicado en el proyecto webapi para colocarla la cadena de conexion de la base de datos, una vez modificado el app.setting se tiene que correr las migraciones desde la terminal el siguiente comando "dotnet ef database update" ubicado en la carpeta del proyecto Application.
