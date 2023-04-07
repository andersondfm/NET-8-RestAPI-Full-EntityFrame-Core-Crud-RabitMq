### NET-6-RestAPI-Full-EntityFrame-Core-Crud
Este é um projeto de API RESTful em .NET 6 usando o Entity Framework Core para implementar operações CRUD (Criar, Ler, Atualizar, Excluir) em um banco de dados. O projeto também inclui a integração com RabbitMQ e um aplicativo de console que consome a fila de produtos.

### Tecnologias
Este projeto utiliza as seguintes tecnologias:

 .NET 6
 Entity Framework Core 6
 ASP.NET Core Web API
 RabbitMQ
 Microsoft SQL Server (ou outro banco de dados compatível com o Entity Framework Core)

### Configuração
 Antes de executar o projeto, certifique-se de ter instalado o .NET 6 SDK em sua máquina e que seu banco de dados esteja configurado corretamente.
 
Clone o repositório para sua máquina local.
Abra o projeto em seu editor de código preferido.
Configure a conexão do banco de dados no arquivo appsettings.json.
Abra o console do NuGet e execute o comando dotnet restore para instalar as dependências do projeto.
Execute o comando dotnet ef database update para criar as tabelas do banco de dados.
Execute o comando dotnet run para iniciar o servidor de desenvolvimento.
Para instalar O rabbitMQ usa o Docker e segue abaixo o comando para instalação.

docker pull rabbitmq:3-management
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management


### Rotas
O projeto tem as seguintes rotas implementadas:

GET /api/produtos - Retorna uma lista de todos os produtos.
GET /api/produtos/{id} - Retorna um único produto pelo ID.
POST /api/produtos - Cria um novo produto.
PUT /api/produtos/{id} - Atualiza um produto existente pelo ID.
DELETE /api/produtos/{id} - Exclui um produto existente pelo ID.

### Testes
O projeto também inclui testes unitários para as operações CRUD da API.

Para executar os testes, execute o comando dotnet test no console do NuGet.

### Contribuindo
Sinta-se à vontade para contribuir com o projeto fazendo um fork e enviando um pull request com suas alterações.

### Licença
Este projeto é licenciado sob a MIT License.
