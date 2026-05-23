# Gerenciamento de Tarefas App

Sistema de Gerenciamento de Tarefas desenvolvida com operações CRUD e gerado com [Angular CLI](https://github.com/angular/angular-cli) versão 18.2.21.

## Início Rápido

```bash
# Clone o repositório
git clone https://github.com/jordanjsantos/task-management.git

# Acesse o diretório do projeto
cd task-management/frontend/task-management-app/ (Para sistemas Linux)

cd task-management\frontend\task-management-app\ (Para sistemas Windows)

# Instale as dependências
npm install

# Inicie o servidor
ng serve
```

- HTTP: `http://localhost:4200/`

## Estrutura do Projeto

```
task-management-app/
└── src/
    └── app/
        ├── models/
        │   └── task.ts
        ├── pages/
        │   └── tasks/
        │       ├── tasks.component.css
        │       ├── tasks.component.html
        │       ├── tasks.component.spec.ts
        │       └── task.component.ts
        └── services/
            └── task.component.ts
```