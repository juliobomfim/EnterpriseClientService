# EnterpriseClientService

Esta API em .NET utiliza o padrão CQRS (Command Query Segregation Responsibility) para gerenciar operações de leitura e gravação, com SQL Server para gravação e MongoDB para leitura.

## Funcionalidades

- Listagem de Clientes: Visualizar os clientes cadastrados.
- Cadastro e Edição de Clientes: Inserir e editar dados dos clientes.
- Remoção de Clientes: Excluir clientes.

## Frameworks

- .NET 8 & ASP.NET Core Web API (RESTful).
- Entity Framework Core (ORM).
- SQLService como branco de dados relacional.
- MongoDB como banco de dados para leitura.
- Swagger.

## Requisitos

- .NET Core 8 SDK.
- SQL Server (Banco Relacional).
- MongoDB (CQRS).

## Como executar
- Rodar `docker compose up -d`.
- Executar comando `dotnet run`.
- As migrations serão executadas automaticamente.

## Dados de conexão (Bancos)
- SQLServer - Para acessar login: `sa` senha: `ECS#123!!&_-__`.
- MongoDB   - Para acessar o mongoExpress utilize login: `admin` senha: `MongoDB!`.
