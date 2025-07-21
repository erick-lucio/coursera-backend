# WebApiCRUD (.NET 8)

## Recursos
- ✅ Endpoints CRUD (GET, POST, PUT, DELETE)
- ✅ Validação com FluentValidation 11.8+
- ✅ Middleware de logging e autenticação
- ✅ Estrutura compatível com GitHub e Copilot

## Executar

```bash
dotnet restore
dotnet run
```

## Testar com curl

```bash
curl -X POST https://localhost:5001/api/user -H "X-Api-Key: test123" -H "Content-Type: application/json" -d "{\"id\":1,\"name\":\"John\",\"email\":\"john@example.com\"}" --insecure
```