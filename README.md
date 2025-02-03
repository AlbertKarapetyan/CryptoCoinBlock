# CryptoCoinBlock Project

## Project Overview

CryptoCoinBlock is a scalable cryptocurrency data management system designed to import and manage blockchain data for multiple coins, including Bitcoin, Dogecoin, Dashcoin, and others. This solution utilizes clean architectural principles, MediatR for CQRS, and a domain-driven approach to encapsulate business logic effectively.

## Key Features

- **Multi-Coin Support:** Import and query blocks for Bitcoin, Dogecoin, Dashcoin, and other cryptocurrencies.
- **Command and Query Separation:** Uses MediatR for clean separation of business logic.
- **Extensible Architecture:** Built for easy extension and maintainability.
- **Generic Methods:** Efficient and reusable methods are implemented to handle operations across multiple coin types.
- **Async Import Endpoint:** A single unified endpoint allows importing of blocks asynchronously for all supported coins.
- **Rate Limiting Middleware:** Middleware is included to enforce rate limits on API requests, ensuring fair usage and protecting the service from abuse.
- **Data Transfer Objects (DTOs) and AutoMapper:** Simplifies data mapping between layers using DTOs for clean data structures and AutoMapper to streamline transformations.
- **API Gateway Support:** CM.APIGateway enables unified access to different cryptocurrency services through a single entry point, providing routing and transformation capabilities.

## Architecture Overview

- **API Layer:** Handles incoming HTTP requests and routes them to application services.
- **Application Layer:** Contains commands, queries, and handlers using MediatR.
- **Domain Layer:** Manages core business logic and domain rules.
- **Infrastructure Layer:** Provides integration with data storage and third-party services.
- **DTO Project:** A dedicated project to define clean data structures used to transfer information between layers, ensuring separation of concerns and consistent data models.
- **API Gateway (CM.APIGateway):** Provides centralized routing for all API requests to backend services, simplifying access and management.

### Design Patterns Used

- **CQRS (Command Query Responsibility Segregation):** Separates commands (state changes) from queries (data retrieval).
- **Dependency Injection (DI):** Ensures loose coupling of components.
- **Mediator Pattern:** Manages communication between handlers using MediatR.
- **Domain-Driven Design (DDD):** Encapsulates business logic in domain models.
- **Data Mapping with AutoMapper:** Streamlines object-to-object mapping to avoid boilerplate code.
- **API Gateway Pattern:** Centralized entry point for managing requests to backend services.

## Getting Started

### Prerequisites

- **.NET 8.0 SDK**
- **Visual Studio 2022 or VS Code**
- **Postman (optional)** for API testing

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd CryptoCoinBlock
   ```
2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
3. Build the solution:
   ```bash
   dotnet build
   ```
4. Run the project:
   ```bash
   dotnet run --project CryptoCoinBlock
   ```
5. The API will be available at `http://localhost:5000`.

### Running Tests

To execute unit tests:

```bash
   dotnet test
```

## API Gateway (CM.APIGateway)

CM.APIGateway serves as a centralized entry point to interact with multiple cryptocurrency APIs, simplifying requests and ensuring efficient routing.

### API Gateway Configuration

- **Routing:**
  - `POST /api/{coin}/Import` -> Maps to `{coin}/Import`
  - `GET /api/{coin}/Get` -> Maps to `{coin}/GetHistory`
- **Host and Ports:** Requests are forwarded to `localhost:...`.
- **Header Transformations:** Ensures proper content-type settings for JSON-based requests.
- **Global Configuration:**
  - `RequestIdKey`: Tracks API requests.
  - `BaseUrl`: `http://localhost:...`
- **Ocelot Configuration:** API Gateway is built using **Ocelot**, with settings stored in `ocelot.json`. The configuration includes automatic reloading (`"AutoReload": true`), allowing real-time updates without restarting the gateway service.
	
### Testing API Gateway

A Postman collection (`CM.APIGateway.postman_collection.json`) is provided to facilitate API testing through the gateway.

## Docker Instructions

### Building the Docker Image

1. Navigate to the project directory containing the Dockerfile.

   ```bash
   cd CryptoCoinBlock
   ```

2. Build the Docker image:

   ```bash
   docker build -t cryptocoinblock-image .
   ```

3. During the build process, the following steps are performed:

   - The entire solution is copied, and NuGet packages are restored.
   - Entity Framework Core tools are installed for handling migrations.
   - Unit tests for both CM.Domain.Tests and CM.API.Tests are executed. If any test fails, the build process will stop.
   - The solution is built in Release mode, and the output is published.

### Running the Docker Container

4. Run the Docker container:

   ```bash
   docker run -p 5000:5000 cryptocoinblock-image
   ```

5. The application will be available at `http://localhost:5000`.

### Docker Compose for Database Migration

1. Create and run services defined in the `docker-compose.yml` file:

   ```bash
   docker-compose up
   ```

2. The `db-migrator` service, defined as part of the Docker Compose configuration, applies the necessary database migrations using the CM.Data.Migrations project before starting the API container. This service ensures schema consistency by updating the PostgreSQL database defined in the `ccb-postgresql` service.

## API Endpoints

### Bitcoin Controller

- **POST /Bitcoin/Import:** Imports a new block.
- **GET /Bitcoin/GetHistory:** Retrieves historical block data.

### Dogecoin Controller

- **POST /Dogecoin/Import:** Imports a new block.
- **GET /Dogecoin/GetHistory:** Retrieves historical block data.

### Unified Import Endpoint

- **POST /AllCoins/Import:** Imports blocks asynchronously for all supported cryptocurrencies in a single request.

#### Sample Request (Import)

```json
POST /AllCoins/Import
{
  "isTest": false
}
```

## Middleware for Rate Limiting

The project includes a custom middleware to enforce API rate limits, protecting the service from excessive traffic and ensuring fair resource usage. Configuration allows adjusting request thresholds and time windows.

### RateLimitingMiddleware Details

The `RateLimitingMiddleware` monitors incoming API requests and applies restrictions based on configurable thresholds. It helps prevent abuse by limiting the number of requests a client can make within a specified time frame.

**Key Features:**

- Tracks API usage per client.
- Sends `429 Too Many Requests` responses when limits are exceeded.
- Fully configurable for time window and request thresholds.

**How to Enable:** The middleware is added in `Program.cs` using:

```csharp
app.UseMiddleware<RateLimitingMiddleware>();
```

## Project Structure

```
CM.APIGateway            # Centralized entry point
CryptoCoinBlock
├── CM.API               # API Layer
├── CM.Application       # Application Layer (Commands, Queries)
├── CM.Domain            # Domain Models and Business Logic
├── CM.Infrastructure    # Data Persistence and Integration
├── CM.DTO               # Data Transfer Object Definitions
├── CM.API.Tests         # Unit tests for the API layer
├── CM.Domain.Tests      # Unit tests for the Domain layer
├── CM.Data.Migrations   # Project for handling database migrations
```

## Test Projects

### CM.API.Tests

This project contains unit tests for the API layer to ensure that controllers, middleware, and endpoint behavior work as expected. Tests cover the correct handling of requests and responses, including validations, success, and error scenarios.

### CM.Domain.Tests

This project focuses on testing the domain logic to ensure that core business rules are enforced correctly. It includes tests for domain models, value objects, and business rule validations.

## Database Migrations

### CM.Data.Migrations

This project is responsible for managing database schema changes and versioning. It uses Entity Framework Core to handle migrations and updates to the database schema. Developers can apply migrations using the following commands:

- Add a new migration:
  ```bash
  dotnet ef migrations add <MigrationName> --project CM.Data.Migrations
  ```
- Update the database:
  ```bash
  dotnet ef database update --project CM.Data.Migrations
  ```

## Additional Configuration Details

### Logging

- The application uses `LoggerFactory` to set up logging with console and debug outputs.
- Developers can extend logging configurations by modifying the service registration in `Program.cs`.

### Health Checks

- A health check endpoint is available at `/health`, providing a simple way to verify the application’s status.
- This can be extended to include more detailed health reporting if required.

### CORS Policy

- The project uses a basic CORS policy allowing all origins but restricting methods to `GET` and `POST`.
- For production, it is recommended to tighten CORS policies to allow only trusted domains and specific HTTP methods.

## License

This project is licensed under the MIT License.

