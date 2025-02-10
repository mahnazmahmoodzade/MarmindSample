## Run with Docker

To run the application with Docker:

```bash
docker-compose up --build
```

This will start the backend, database, and seq services. Navigate to <http://localhost:8080> to access the application.

## Database

The application uses PostgreSQL database which runs in a container:
- Container name: `marmind-sample-db`
- Port: 5432
- Database name: MarmindSampleDb
- Username: postgres
- Password: postgres

You can connect to the database using these credentials when the Docker container is running.

## View Logs

To view application logs:
1. Ensure the Seq container is running (included in `docker-compose up`)
2. Navigate to <http://localhost:5341>
3. Use Seq's interface to search, filter, and analyze logs in real-time

## Test API Endpoints using Bruno

Bruno is a lightweight alternative to Postman for testing APIs and comes with a built-in environment manager.
To test API the endpoints, follow these steps:

1. Download and install Bruno from <https://www.usebruno.com/downloads>
2. Open Bruno and select "Open Collection"
3. Navigate to and select this folder: `src\Web\bru_collection`
4. Run the "login" request first - it's preconfigured with credentials:
   - Email: administrator@localhost
   - Password: Administrator1!
   - The access token will be automatically stored for subsequent requests
5. After login, you can run any other API request in the collection

The collection includes TodoItem endpoints with built-in assertions that verify:
- Response status codes
- Empty responses where appropriate
- Data consistency between request and response




