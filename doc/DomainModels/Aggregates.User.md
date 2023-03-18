# Domain Aggregates

## User

```csharp
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root
    {
        public User User { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime updatedDateTime { get; set; }
    }
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "firstName": "Tiffany",
    "lastName": "Doe",
    "email": "user@gmail.com",
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
