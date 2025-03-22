# 🏥 MedIapp

**MedIapp** es una aplicación CRUD desarrollada con **.NET 8** y **Entity Framework Core**, diseñada para gestionar información médica de pacientes.

## 🚀 Características  
✅ Gestión de pacientes (Crear, Leer, Actualizar, Eliminar).  
✅ API RESTful con ASP.NET Core.  
✅ Uso de Entity Framework Core con SQL Server.  
✅ Interfaz web con Razor Pages o Blazor (según implementación).  

---

## 📌 Requisitos Previos  
Antes de ejecutar el proyecto, asegúrate de tener instalado:  
- [.NET SDK 8](https://dotnet.microsoft.com/download)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) o SQLite  
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o VS Code con la extensión de C#  

---

## ⚙️ Instalación y Configuración  
### 1️⃣ **Clona el repositorio**  
```bash
git clone https://github.com/DevelUps/MedIapp.git
cd MedIapp
2️⃣ Configura la base de datos
Edita el archivo appsettings.json para definir la cadena de conexión:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MedIappDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
}
3️⃣ Aplica las migraciones de Entity Framework
bash
Copiar
Editar
dotnet ef database update
4️⃣ Ejecuta la aplicación
bash
Copiar
Editar
dotnet run
🛠️ Uso de la API (si incluye endpoints REST)
Método	Endpoint	Descripción
GET	/api/pacientes	Lista todos los pacientes
GET	/api/pacientes/{id}	Obtiene un paciente por ID
POST	/api/pacientes	Crea un nuevo paciente
PUT	/api/pacientes/{id}	Actualiza un paciente existente
DELETE	/api/pacientes/{id}	Elimina un paciente
Puedes probar estos endpoints con Postman o Swagger (/swagger en el navegador).

🤝 Contribución
Si deseas contribuir, haz un fork, crea una rama y abre un pull request.

📜 Licencia
Este proyecto está bajo la licencia MIT.

📌 Autor: DevelUps
📆 Última actualización: 2025
