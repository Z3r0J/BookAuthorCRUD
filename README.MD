## Book Author CRUD (TEST PROJECT)

<img src="https://i0.wp.com/www.blinkingcaret.com/wp-content/uploads/2018/01/asp_net_core_and_angular_logo.png" width="500" />

<br/>

- Develop a WebApi based on a DDD Pattern in .Net6

- Develop a Angular CRUD Application to maintain the data with validation in front and backend ( use FluentValidation Syntax in Both)

- The Angular Application also should have a overview with an grid

- The Application should be startable with a docker-compose and checkable

<br/>

### Requirements to run the project

#

- [Node 19.0.0](https://nodejs.org/en/download/)

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

- [SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

- [Angular CLI 16](https://angular.io/cli)

- If you want to run the project using docker, you need to install [Docker](https://www.docker.com/products/docker-desktop)

### How to run

#

#### Optionals Configurations

<br>

- You can change the connection string in the following file if you want to use another database:

```json

// Go to the backend folder

cd backend

// Go to the BookAuthorCRUD folder

cd BookAuthorCRUD

 // Open the appsettings.json file and change the following line:

"ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }

```

<br>

- If you want to use another connection string, using the docker-compose.yml file, change the following environment variables:

```bash

# CONNECTION STRING

- ASPNETCORE_CONNECTIONSTRING = YOUR_CONNECTION_STRING

# OR INMEMORY DATABASE

- ASPNETCORE_USEINMEMORYDATABASE = true


```

<br/>

#### Using Docker

- Open the terminal and go to the root folder of the project

- Run the following command:

```bash

# Run the containers

docker-compose up

# or

docker compose up

```

- After the containers are up, open the browser and go to the following url:

```bash

http://localhost:8080

```

<br/>

#### Using the terminal

#

- To run the frontend side, open the terminal and execute one by one the following commands:

```ruby

# Go to the frontend folder

cd frontend

# Install the dependencies

npm install

# Run the frontend

ng serve

```

- To run the backend side, open the terminal and execute one by one the following commands:

```ruby

# Go to the backend folder

cd backend

# Go to the BookAuthorCRUD folder

cd BookAuthorCRUD

# Run the migrations
dotnet tool install --global dotnet-ef

dotnet ef database update

# Go to the root folder

cd ..

dotnet run --project BookAuthorCRUD

```

### Tools and technologies

#

This is a test project I called Book App, which is an app that is using the following technologies:

```csharp
# Frontend

- Angular 16
- Bootstrap 5.3
- Angular Material 16
- Axios
- FluentValidation-ts

# Backend

- .NET 6
- Entity Framework Core 7
- SQL Server 2019
- CQRS
- MediatR
- AutoMapper
- FluentValidation
- LanguageExt
- Docker
- DDD (Domain Driven Design)
- Unit Testing (xUnit)

```

### Made with ❤ by [Jean Carlos Reyes Encarnacion](https://linkedin.com/in/z3r0j/) ~ Book Author CRUD
