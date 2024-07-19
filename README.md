# api-clientes #RESTAPI
Introducción
Esta es una REST API creada con ASP.NET Core Web API utilizando Minimal API. La API se conecta a una base de datos PostgreSQL utilizando Entity Framework, y permite realizar operaciones CRUD sobre una lista de clientes. Para utilizar esta API, solo necesitas configurar tus datos de usuario de PostgreSQL.

Requisitos Previos
Antes de comenzar, asegúrate de tener minimamente estos requisitos instalados:

.NET 6.0 SDK
PostgreSQL
Un editor de código como Visual Studio o Visual Studio Code

Pasos para Configurar y Utilizar la API
1. Clonar el Repositorio
Clona el repositorio de GitHub en tu máquina local:

git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio

2. Configurar la Cadena de Conexión
Copia el archivo appsettings.example.json y renómbralo a appsettings.json. Luego, abre appsettings.json y actualiza la cadena de conexión con tus propios datos de PostgreSQL:
{
  "ConnectionStrings": {
    "PostgreSQLConnection": "Server=127.0.0.1;Port=5432;Database=ClientsDb;User Id=postgres;Password=YOUR_PASSWORD"
  }
}

3. Restaurar Paquetes de NuGet
Navega al directorio del proyecto y restaura los paquetes de NuGet necesarios:
dotnet restore

4. Aplicar Migraciones y Crear la Base de Datos
Aplica las migraciones para crear la base de datos y las tablas necesarias:
dotnet ef database update

5. Ejecutar la API
Inicia la aplicación:
dotnet run



