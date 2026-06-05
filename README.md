# GAMESTORE API

##### A backend application where you can manage *(Games)* & *(Genres of the Games)*, with Clean Architecture.

### *What the application has*
- Add *(Genres)*
- Add *(Games)* with:
  - Title
  - Price
  - Genre
  - Description
- View All *(Games)* & *(Genres)*
- View a *specific* Game or Genre by *ID*
- Update *(Games)* or *(Genres)*
- Delete *(Games)* *(Genres)*
- Data gets saved to database
- Clean Architecture + CQRS oattern
- Testable thru *Swagger UI*

## How to run the project
### Requirements
- [.NET 8 SDK] (https://dotnet.microsoft.com/download)
- [Visual Studio 2022] Why? = it includes SQL Server LocalDB. (https://visualstudio.microsoft.com/)

### Steps
1. Clone the repository link here → " https://github.com/Liina00/GameStore.git "  ←
```bash
   git clone https://github.com/Liina00/GameStore.git
   cd GameStore
```
2. Apply database migrations
```bash
   dotnet ef database update
   ```
3. Run the API
```bash
   dotnet run
```
4. Open Swagger  go to  → " https://localhost:7112/swagger/index.html "  ←

# API Endpoints

###  Games
| Method | Endpoint | Description |
|--------|-----------|-------------|
| GET | `/api/games` | Get all *(Games)* |
| GET | `/api/games/{id}` | Get a "single" Game by ID |
| POST | `/api/games` | Add a new Game *(Title, Description, Price, GenreId)* |
| PUT | `/api/games/{id}` | Update a *Game* |
| DELETE | `/api/games/{id}` | Delete a *Game* |

###  Genres
| Method | Endpoint | Description |
|--------|-----------|-------------|
| GET | `/api/genres` | Get all *(Genres)* |
| GET | `/api/genres/{id}` | Get a "single" Genre by ID |
| POST | `/api/genres` | Add a new Genre |
| PUT | `/api/genres/{id}` | Update a *Genre* |
| DELETE | `/api/genres/{id}` | Delete a *Genre* |

## Database
- SQL Server LocalDB
- ORM: Entity Framework Core 8
- Migrations
  - InitialCreate - It creates the *Games* and *Genres* tables
 
## Projekt structure
- GameStoreAPI - Controllers + Swagger
- GameStore.Application - Commands, queries, handlers and Dtos
- GameStore.Domain - Entities
- GameStore.Infrastructure - DbContext + Repositories

### *Reflection*
- The setup and preperation of Clean Architexcture setup
- CRUD went well
