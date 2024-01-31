# Hotel Booking Manager API 🏨
Software de booking de várias redes de hóteis no formato de uma RESTful API com operações de CRUD.
<br><br>
O projeto foi feito utilizando C#, ASP.NET Core, .NET 6.0, Entity Framework Core (ORM) e MySQL (inicialmente foi desenvolvido com MS SQL Server) para gerenciamento do banco de dados e dockerizado para fácil execução em qualquer máquina.<br><br>
A autenticação e autorização foi feita com JWT. Os testes estão sendo desenvolvidos usando xUnit.<br><br>
Deploys:
- Banco de Dados: Railway
- API: Heroku


## Feito com 👨‍💻:
- C#
- .NET 6.0
- ASP.NET Core
- Entity Framework Core
- MySQL (o código para migração para MS SQL Server está no projeto)
- Docker
- JWT
- Testes de integração com xUnit
- Arquitetura em Camadas

## Como rodar o projeto:
1)  Clone o repositório;
2)  Entre no diretório do projeto;
3)  Inicie o container do banco de dados: `docker-compose up -d --build`;
4)  Entre no diretório src;
5)  Instale as dependências: `dotnet restore`;
6)  Entre em src/HotelManagerAPI e inicie o projeto: `dotnet run`;

## Tabelas:
![Entity Relationship Diagram](/er-diagram.jpeg)
- Cities: armazena um conjunto de cidades nas quais os hotéis estão localizados. Uma cidade pode ter vários hotéis.
- Hotels: armazena os hotéis da aplicação. Um hotel pode ter vários quartos.
- Rooms: armazena os quartos de cada hotel. Um quarto pode ter várias reservas.
- Users: armazena as pessoas usuárias do sistema. Um usuário pode ter várias reservas.
- Bookings: armazena as reservas dos quartos de hotéis.
  
## Documentação (em desenvolvimento):
![Swagger Routes](/swagger-routes.jpeg)

## Rodando os testes:
1)  Para rodar os testes: `dotnet test`