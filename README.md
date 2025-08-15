# Product Management Application

This repository contains both the backend (ASP.NET Core Web API) and frontend (Angular) for a simple Product Management application with Main CRUD operations.
It follows the 3-tier architecture:
- Presentation Layer (Product.API) – Handles incoming HTTP requests via controllers and sends responses to the client.
- Business Logic Layer (Product.BL) – Contains service classes and DTOs where all business rules, validations, and processing logic are implemented.
- Data Access Layer (Product.DAL) – Uses Entity Framework Core and DbContext to interact with the database.

# Technologies Used

# Backend
- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- LINQ
  
# Frontend
- Angular 20
- TypeScript
- HTML5, CSS3


### API Documentation

The API follows REST principles and uses JSON for all requests and responses.

🔹 GET /api/Item
Retrieve all items.

Response example:
[

  {
    "id": 4,
    "name": "milk",
    "description": "milk",
    "categoryId": 2
  },
]

🔹 GET /api/Item/{Id}
Retrieve an item with that ID.

Response example:
  {
    "id": 4,
    "name": "milk",
    "description": "milk",
    "categoryId": 2
  }

🔹 POST /api/Item
Create new Item.

Request Body example:
{
  "name": "string",
  "description": "string",
  "categoryId": 0
}

Response example:
{
  "id": 4,
  "name": "string",
  "description": "string",
  "categoryId": 1
}

🔹 PUT /api/Item
Update an existing item.
Request Body example:

{
  "name": "updated name",
  "description": "updated description",
  "categoryId": 1
}

Response example:
{
  "id": 4,
  "name": "updated name",
  "description": "updated description",
  "categoryId": 1
}

🔹 PATCH /api/Item
Update an existing item (partial update).
Request Body example:

{
  "name": "updated name",
  "description": "updated description",
  "categoryId": 1
}

Response example:
{
  "id": 4,
  "name": "updated name",
  "description": "updated description",
  "categoryId": 1
}

🔹 DELETE /api/Item/{id}
Delete an item.

Path Parameter:
id (integer, required) — The ID of the item to delete.


