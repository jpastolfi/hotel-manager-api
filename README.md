**Hotel Booking Manager API **

Booking software for multiple hotel chains in the form of a RESTful API with CRUD operations.

**Description**

The project was developed using C#, ASP.NET Core, .NET 6.0, Entity Framework Core (ORM) and MySQL (initially developed with MS SQL Server) for database management and dockerized for easy execution on any machine.

Authentication and authorization was done with JWT. Tests are being developed using xUnit.

**Technologies used:**

- C#
- .NET 6.0
- ASP.NET Core
- Entity Framework Core
- MySQL
- Docker
- JWT
- Integration tests with xUnit
- Layered Architecture

**How to run the project:**

1. Clone the repository;
2. Enter the project directory;
3. Start the database container: `docker-compose up -d --build`;
4. Enter the src directory;
5. Install the dependencies: `dotnet restore`;
6. Enter src/HotelManagerAPI and start the project: `dotnet run`;

**Tables:**

Entity Relationship Diagram: /er-diagram.jpeg

- Cities: stores a set of cities in which the hotels are located. A city can have multiple hotels.
- Hotels: stores the hotels in the application. A hotel can have multiple rooms.
- Rooms: stores the rooms of each hotel. A room can have multiple reservations.
- Users: stores the system users. A user can have multiple reservations.
- Bookings: stores the reservations for hotel rooms.

**Documentation (under development):**

Swagger Routes: /swagger-routes.jpeg

**Running the tests:**

1. To run the tests: `dotnet test`