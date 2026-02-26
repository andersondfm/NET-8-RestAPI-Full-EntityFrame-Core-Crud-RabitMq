# 🚀 NET 8 REST API - Full CRUD com Entity Framework Core e RabbitMQ

API RESTful robusta desenvolvida em .NET 8 seguindo os princípios de **Clean Architecture**, implementando operações CRUD completas, autenticação JWT, integração com RabbitMQ e logging estruturado.

## 📋 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [Arquitetura](#-arquitetura)
- [Tecnologias](#-tecnologias)
- [Funcionalidades](#-funcionalidades)
- [Pré-requisitos](#-pré-requisitos)
- [Instalação](#-instalação)
- [Configuração](#-configuração)
- [Executando o Projeto](#-executando-o-projeto)
- [Autenticação](#-autenticação)
- [Endpoints da API](#-endpoints-da-api)
- [RabbitMQ](#-rabbitmq)
- [Testes](#-testes)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Contribuindo](#-contribuindo)
- [Licença](#-licença)

## 🎯 Sobre o Projeto

Este projeto é uma API REST completa que demonstra as melhores práticas de desenvolvimento em .NET 8, incluindo:
- **Clean Architecture** com separação clara de responsabilidades
- **CRUD completo** de produtos com paginação, ordenação e filtros
- **Autenticação JWT** com ASP.NET Identity e controle de roles
- **Mensageria** assíncrona com RabbitMQ
- **Logging estruturado** com Serilog persistido em SQL Server
- **Testes unitários** com xUnit
- **AutoMapper** para mapeamento de objetos
- **Swagger** para documentação da API

## 🏗️ Arquitetura

O projeto segue os princípios de **Clean Architecture** e **Domain-Driven Design (DDD)**, dividido em camadas:

```
┌─────────────────────────────────────────┐
│         ANDERSONDFM.API                 │  ← Camada de Apresentação
│  (Controllers, Program, Middleware)     │
└─────────────────────────────────────────┘
              ↓
┌─────────────────────────────────────────┐
│      ANDERSONDFM.Aplicacao              │  ← Camada de Aplicação
│  (Services, ViewModels, Interfaces)     │
└─────────────────────────────────────────┘
              ↓
┌─────────────────────────────────────────┐
│       ANDERSONDFM.Dominio               │  ← Camada de Domínio
│     (Entidades, Interfaces)             │
└─────────────────────────────────────────┘
              ↓
┌─────────────────────────────────────────┐
│        ANDERSONDFM.Infra                │  ← Camada de Infraestrutura
│   (Repositórios, Contexto, Migrations)  │
└─────────────────────────────────────────┘
              ↓
┌─────────────────────────────────────────┐
│       ANDERSONDFM.Infra.IoC             │  ← Injeção de Dependências
│  (DI Container, AutoMapper Profile)     │
└─────────────────────────────────────────┘
```

Projetos adicionais:
- **ANDERSONDFM.Compartilhado**: Classes compartilhadas e notificações
- **ANDERSONDFM.Integracao**: Integração com RabbitMQ
- **ANDERSONDFM.Tests**: Testes unitários
- **RabitMQProduct.ConsoleApplication**: Consumer do RabbitMQ

## 🛠️ Tecnologias

### Core
- **.NET 8** - Framework principal
- **C# 12** - Linguagem de programação
- **ASP.NET Core 8** - Web API Framework
- **Entity Framework Core 8** - ORM para acesso a dados

### Banco de Dados
- **Microsoft SQL Server** - Banco de dados principal
- **EF Core Migrations** - Versionamento do banco

### Autenticação & Segurança
- **ASP.NET Core Identity** - Gerenciamento de usuários
- **JWT Bearer Authentication** - Autenticação baseada em tokens
- **Role-Based Authorization** - Controle de acesso baseado em roles

### Mensageria
- **RabbitMQ** - Message broker para comunicação assíncrona
- **RabbitMQ.Client** - Cliente .NET para RabbitMQ

### Logging & Monitoramento
- **Serilog** - Logging estruturado
- **Serilog.Sinks.MSSqlServer** - Persistência de logs no SQL Server
- **Serilog.Sinks.Console** - Logs no console

### Ferramentas & Utilitários
- **AutoMapper** - Mapeamento objeto-para-objeto
- **Swagger/OpenAPI** - Documentação interativa da API
- **Newtonsoft.Json** - Serialização JSON
- **xUnit** - Framework de testes
- **Docker** - Containerização (RabbitMQ)

### Patterns & Práticas
- ✅ Clean Architecture
- ✅ Repository Pattern
- ✅ Dependency Injection
- ✅ SOLID Principles
- ✅ Unit of Work
- ✅ API Result Pattern

## ✨ Funcionalidades

### 🔐 Autenticação e Autorização
- Registro de usuários (comum e admin)
- Login com geração de token JWT
- Proteção de rotas por roles (User, Admin)
- Validação de tokens

### 📦 Gestão de Produtos
- Listagem com paginação, ordenação e filtros
- Busca por ID
- Cadastro de novos produtos
- Atualização de produtos existentes
- Exclusão de produtos
- Publicação de eventos no RabbitMQ após operações

### 📊 Logging
- Logs estruturados com Serilog
- Persistência automática no SQL Server
- Logs de requisições HTTP
- Rastreamento de erros

### 🔄 Mensageria
- Producer: Publicação de mensagens no RabbitMQ
- Consumer: Aplicação console que consome mensagens da fila

## 📦 Pré-requisitos

Antes de começar, você precisa ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (versão 8.0 ou superior)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (Express, Developer ou superior)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (para RabbitMQ)
- IDE de sua preferência ([Visual Studio 2022](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/) ou [Rider](https://www.jetbrains.com/rider/))

## 🚀 Instalação

### 1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/NET-8-RestAPI-Full-EntityFrame-Core-Crud-RabitMq.git
cd NET-8-RestAPI-Full-EntityFrame-Core-Crud-RabitMq
```

### 2. Instale o RabbitMQ via Docker
```bash
# Pull da imagem do RabbitMQ com management console
docker pull rabbitmq:3-management

# Execute o container
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

Acesse o Management Console em: http://localhost:15672
- **Usuário**: guest
- **Senha**: guest

### 3. Restaure as dependências
```bash
dotnet restore
```

## ⚙️ Configuração

### 1. Configure a Connection String

Edite o arquivo `src/ANDERSONDFM.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=SEU_SERVIDOR;Initial Catalog=ANDERSONDFM.API;Integrated Security=True;TrustServerCertificate=True"
  },
  "JWT": {
    "ValidAudience": "https://localhost:7001",
    "ValidIssuer": "https://localhost:7001",
    "Secret": "SUA_CHAVE_SECRETA_MUITO_SEGURA_COM_MINIMO_32_CARACTERES"
  }
}
```

> ⚠️ **Segurança**: Nunca commite credenciais reais no repositório! Use **User Secrets** ou **variáveis de ambiente** em produção.

### 2. Aplique as Migrations

```bash
cd src/ANDERSONDFM.API
dotnet ef database update
```

Isso criará o banco de dados e todas as tabelas necessárias, incluindo:
- Tabelas do Identity (AspNetUsers, AspNetRoles, etc.)
- Tabela de Produtos
- Tabela de Logs (LogEvents)

## ▶️ Executando o Projeto

### API Principal

```bash
cd src/ANDERSONDFM.API
dotnet run
```

A API estará disponível em:
- **HTTPS**: https://localhost:7001
- **HTTP**: http://localhost:5000
- **Swagger**: https://localhost:7001/swagger

### Consumer do RabbitMQ

Em outro terminal:

```bash
cd src/RabitMQProduct.ConsoleApplication
dotnet run
```

O consumer ficará escutando mensagens da fila `product`.

## 🔐 Autenticação

### 1. Registrar um Usuário

**Endpoint**: `POST /api/auth/cadastrar-usuarios-comum`

```json
{
  "nome": "usuario",
  "email": "usuario@email.com",
  "password": "Senha123!"
}
```

### 2. Fazer Login

**Endpoint**: `POST /api/auth/login`

```json
{
  "nome": "usuario",
  "password": "Senha123!"
}
```

**Resposta**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2026-02-26T14:30:00Z",
  "success": true
}
```

### 3. Usar o Token

Inclua o token no header das requisições protegidas:
```
Authorization: Bearer {seu-token-aqui}
```

No Swagger, clique em **Authorize** e cole o token.

## 🌐 Endpoints da API

### 🔓 Autenticação (Público)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| POST | `/api/auth/login` | Autenticar usuário |
| POST | `/api/auth/cadastrar-usuarios-comum` | Registrar usuário comum |
| POST | `/api/auth/cadastrar-usuarios-admin` | Registrar usuário admin |

### 🔒 Produtos (Requer Autenticação - Role: User)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/produto` | Lista produtos com paginação e filtros |
| GET | `/api/produto/{id}` | Busca produto por ID |
| POST | `/api/produto` | Cria novo produto |
| PUT | `/api/produto/{id}` | Atualiza produto existente |
| DELETE | `/api/produto/{id}` | Remove produto |

### Exemplo: Listar Produtos com Filtros

```
GET /api/produto?pageIndex=0&pageSize=10&sortColumn=Nome&sortOrder=asc&filterColumn=Nome&filterQuery=Produto
```

**Parâmetros**:
- `pageIndex`: Índice da página (padrão: 0)
- `pageSize`: Itens por página (padrão: 10)
- `sortColumn`: Coluna para ordenação (ex: Nome, DataInclusao)
- `sortOrder`: Ordem (asc/desc)
- `filterColumn`: Coluna para filtro
- `filterQuery`: Valor do filtro

### Exemplo: Criar Produto

```json
POST /api/produto
{
  "nome": "Notebook Dell",
  "dataInclusao": "2026-02-26T00:00:00",
  "usuarioInclusao": "admin"
}
```

## 🐰 RabbitMQ

### Configuração

O projeto usa RabbitMQ para mensageria assíncrona:

- **Host**: localhost
- **Porta**: 5672
- **Fila**: product
- **Exchange**: default

### Fluxo de Mensagens

1. **Producer** (API): Quando um produto é criado/atualizado, uma mensagem é publicada na fila
2. **Consumer** (Console App): Consome as mensagens e processa (ex: logging, notificações, sincronização)

### Testando

1. Execute a API e o Consumer
2. Crie um produto via POST `/api/produto`
3. Observe o console do Consumer recebendo a mensagem:
```
Product message received: {"Id":1,"Nome":"Notebook Dell","DataInclusao":"2026-02-26T00:00:00","UsuarioInclusao":"admin"}
```

## 🧪 Testes

O projeto inclui testes unitários com **xUnit** e **InMemory Database**.

### Executar todos os testes

```bash
dotnet test
```

### Executar testes com cobertura

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

### Visualizar relatório de cobertura

Os relatórios HTML estão na pasta `CoverageReport/`. Abra o `index.html` no navegador.

### Testes Implementados

- ✅ `Get_Deve_Retornar_Produto_Quando_Existir`: Verifica busca de produto existente
- ✅ `Get_Deve_Retornar_NoContent_Quando_Nao_Existir`: Verifica comportamento quando produto não existe
- ✅ Outros testes de CRUD

## 📁 Estrutura do Projeto

```
├── src/
│   ├── ANDERSONDFM.API/                    # Camada de Apresentação
│   │   ├── Controllers/                   # Controladores da API
│   │   │   ├── ProdutoController.cs      # CRUD de produtos
│   │   │   └── Security/
│   │   │       └── AuthController.cs     # Autenticação
│   │   ├── Program.cs                     # Configuração da aplicação
│   │   ├── appsettings.json              # Configurações
│   │   └── Dockerfile                     # Container Docker
│   │
│   ├── ANDERSONDFM.Aplicacao/             # Camada de Aplicação
│   │   ├── Interfaces/                   # Contratos de serviços
│   │   ├── Servicos/                     # Implementação de serviços
│   │   ├── ViewModels/                   # DTOs e ViewModels
│   │   └── Requests/                     # Request models
│   │
│   ├── ANDERSONDFM.Dominio/               # Camada de Domínio
│   │   ├── Entidades/                    # Entidades de domínio
│   │   │   └── Produtos.cs              # Entidade Produto
│   │   └── Interfaces/                   # Contratos de repositório
│   │
│   ├── ANDERSONDFM.Infra/                 # Camada de Infraestrutura
│   │   ├── Contextos/                    # DbContext
│   │   ├── Mapeamentos/                  # Configurações EF
│   │   ├── Migrations/                   # Migrations do EF
│   │   └── Repositorio/                  # Implementação de repositórios
│   │
│   ├── ANDERSONDFM.Infra.IoC/             # Injeção de Dependências
│   │   ├── DependencyInjectionConfig.cs # Configuração de DI
│   │   └── AutoMapper/                   # Perfis do AutoMapper
│   │
│   ├── ANDERSONDFM.Compartilhado/         # Classes Compartilhadas
│   │   ├── Interfaces/                   # Interfaces compartilhadas
│   │   ├── Notifications/                # Sistema de notificações
│   │   └── ViewModel/                    # ViewModels compartilhados
│   │
│   ├── ANDERSONDFM.Integracao/            # Integrações Externas
│   │   ├── Servico/
│   │   │   └── RabitMQProducer.cs       # Producer do RabbitMQ
│   │   └── Interface/                    # Contratos de integração
│   │
│   ├── ANDERSONDFM.Tests/                 # Testes Unitários
│   │   └── UnitTestProduto.cs           # Testes de produtos
│   │
│   └── RabitMQProduct.ConsoleApplication/ # Consumer RabbitMQ
│       └── Program.cs                     # Consumer da fila
│
├── CoverageReport/                         # Relatórios de cobertura
├── ANDERSONDFM.API.sln                    # Solution
└── README.md                              # Este arquivo
```

## 🤝 Contribuindo

Contribuições são bem-vindas! Siga estas etapas:

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

### Padrões de Código

- Siga as convenções de código C# (.NET)
- Mantenha a cobertura de testes acima de 80%
- Documente métodos públicos com XML comments
- Use nomes descritivos para variáveis e métodos

## 📄 Licença

Este projeto está licenciado sob a **MIT License** - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

## 📚 Recursos Adicionais

- [Documentação .NET 8](https://learn.microsoft.com/dotnet/core/whats-new/dotnet-8)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [ASP.NET Core Identity](https://learn.microsoft.com/aspnet/core/security/authentication/identity)
- [RabbitMQ Tutorials](https://www.rabbitmq.com/tutorials)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

⭐ **Desenvolvido por Anderson DFM** | Se este projeto foi útil, considere dar uma estrela!
