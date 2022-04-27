# SuperHereos - API Basics

Web API with ASP.NET Core.

- [x] Create a web API project.
- [x] Add a model class and a database context.
- [x] Scaffold a controller with CRUD methods.
- [x] Configure routing, URL paths, and return values.
- [x] Call the web API with Postman.

## Model

- ID (long)
- Name (string)
- Universe (string)
- IsEvil (bool)

## API Calls

| API	                          | Description	                  | Request body  | Response body
| :---------------------------- | :---------------------------- | :------------ | :------------------- 
| GET /api/SuperHeroes          | Get all Super Heroes          | None	        | Array of Super Heroes
| GET /api/SuperHeroes/{id}     | Get a Super Hero by ID        | None	        | Super Hero
| POST /api/SuperHeroes         | Add a new item	              | Super Hero	  | Super Hero
| PUT /api/SuperHeroes/{id}     | Update an existing Super Hero | Super Hero	  | None
| DELETE /api/SuperHeroes/{id}  | Delete a Super Hero	          | None	        | None

## Postman

- Run project first then open up Postman
- https://localhost:yourPortNum
- *Note* API is setup with InMemoryDatabase option. The data is lost when the application is shut down.
  
### Request/Response Body Example
```  
{
  "id": 1,
  "name": "Iron Man",
  "universe": "Marvel",
  "isEvil": false
}
```

![This is an image](https://i0.wp.com/www.readingorders.net/wp-content/uploads/2020/12/spider-ham.jpg?resize=300%2C300)
