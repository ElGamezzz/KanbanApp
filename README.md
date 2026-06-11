#  Kanban App (ASP.NET Core + Blazor Server)

Una aplicación web Full-Stack para la gestión de tareas estilo Kanban, desarrollada con **ASP.NET Core Web API** en el backend y **Blazor Server** en el frontend. Permite crear, mover (con Drag & Drop), actualizar y eliminar tareas en tiempo real.

##  Características Principales

- **Tablero Interactivo**: 3 columnas (To Do, In Progress, Done) con contadores en tiempo real.
- **Drag & Drop Nativo**: Arrastra y suelta tarjetas entre columnas usando HTML5 nativo, sin librerías pesadas.
- **Actualización en Tiempo Real**: Gracias a Blazor Server y SignalR, los cambios se reflejan instantáneamente.
- **Diseño Responsivo**: Se adapta perfectamente a dispositivos móviles (las columnas se apilan verticalmente).
- **Animaciones Suaves**: Transiciones CSS al crear o mover tareas para una mejor experiencia de usuario (UX).
- **Confirmación de Eliminación**: Diálogo nativo del navegador para prevenir borrados accidentales.

##  Tecnologías Utilizadas

- **Backend**: ASP.NET Core Web API (.NET 8/10), Entity Framework Core, SQLite.
- **Frontend**: Blazor Server (Interactive Server Render Mode), HTML5, CSS3.
- **Herramientas**: Git, GitHub, Visual Studio / VS Code.

##  Cómo ejecutar el proyecto localmente

### Prerrequisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (versión 8.0 o superior).
- [Git](https://git-scm.com/downloads).

### Pasos de instalación

1. **Clona el repositorio**:
   ```bash
   git clone https://github.com/TU_USUARIO/TU_REPOSITORIO.git
   cd KanbanApp

2. **Restaura las dependencias:**
    ```bash
    dotnet restore

3. **Ejecuta la API (Backend):**
Abre una terminal y ejecuta:
    ```bash
    dotnet run --project Kanban.Api

(La API se ejecutará por defecto en http://localhost:5243. La primera vez creará automáticamente la base de datos kanban.db y un usuario de prueba).

4. **Ejecuta la aplicación Web (Frontend):**
Abre otra terminal (sin cerrar la anterior) y ejecuta:
    ```bash
    dotnet run --project Kanban.Web

(La aplicación web se ejecutará en http://localhost:5028 o el puerto que indique la consola).
Abre tu navegador:
Ve a http://localhost:5028/kanban y ¡comienza a gestionar tus tareas!

 **Estructura del Proyecto**
 ```bash
KanbanApp/
├── Kanban.Api/               # Backend (Web API)
│   ├── Controllers/          # Endpoints REST (TasksController)
│   ├── Data/                 # Contexto de Entity Framework (AppDbContext)
│   ├── Models/               # Entidades (TaskItem, User)
│   └── Program.cs            # Configuración de servicios, BD y Swagger
├── Kanban.Web/               # Frontend (Blazor Server)
│   ├── Components/Pages/     # Componentes de UI (KanbanBoard.razor)
│   ├── Models/               # Modelos compartidos con la API
│   ├── Services/             # Servicio HTTP para consumir la API
│   └── Program.cs            # Configuración de Blazor y HttpClient
└── README.md

 Licencia:
Este proyecto está bajo la Licencia MIT. Siéntete libre de usarlo, modificarlo y aprender de él.
Desarrollado con <3 usando .NET