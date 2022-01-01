docker run -d --rm --name db -p 5555:5432 -e POSTGRES_HOST_AUTH_METHOD=trust postgres
dotnet run