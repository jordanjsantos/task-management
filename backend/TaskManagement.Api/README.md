# API de Gerenciamento de Tarefas

Uma API de gerenciamento de tarefas desenvolvida com operações CRUD, Entity Framework Core, Scalar e Microsoft SQL Server.

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Microsoft SQL Server Express](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us)

## Início Rápido

```bash
# Clone o repositório
git clone https://github.com/jordanjsantos/task-management.git

# Acesse o diretório do projeto
cd task-management/backend/TaskManagement.Api/TaskManagement.Api/ (Para sistemas Linux)

cd task-management\backend\TaskManagement.Api\TaskManagement.Api\ (Para sistemas Windows)

# Execute as migrações
dotnet ef migrations add Initial
dotnet ef database update

# Inicie a API
dotnet run
```

- HTTPS: `https://localhost:7108`
- HTTP: `http://localhost:5249`
- Scalar UI HTTPS: `https://localhost:7108/scalar/v1`
- Scalar UI HTTP: `http://localhost:5249/scalar/v1`

## Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-------------|
| POST | `/api/tasks` | Cria uma tarefa |
| GET | `/api/tasks` | Lista todas as tarefas |
| GET | `/api/tasks/{id}` | Lista uma tarefa pelo ID |
| PUT | `/api/tasks/{id}` | Atualiza uma tarefa |
| DELETE | `/api/tasks/{id}` | Remove uma tarefa |

## Estrutura do Projeto

```
TaskManagement.Api/
├── Program.cs                          # Ponto de entrada do aplicativo 
├── Entities/
│   └── Task.cs                         # Entidade do domínio Task
├── Persistence/
│   └── TaskDbContext.cs                # Entity Framework Core DbContext
├── Controllers/
│   └── TaskController.cs               # Rotas da API 
└── Migrations/                         # Auto-geração EF Core
```