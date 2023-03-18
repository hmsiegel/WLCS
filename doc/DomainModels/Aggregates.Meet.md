# Domain Models

## Meet

```csharp
   Meet Create();
   void AddCompetition(Competition competition);
   void AddPlatform(Platform platform);
```

```json
{
      "id": "00000000-0000-0000-0000-000000000000",
      "year" : "2022",
      "name": "Meet Name",
      "location" : "Anytown, USA",
      "venue" : "Anytown High School",
      "sanctionNumber" : "123456",
      "startDate": "2020-01-01T00:00:00.0000000Z",
      "endDate": "2020-01-01T00:00:00.0000000Z",
      "createdDateTime": "2020-01-01T00:00:00.0000000Z",
      "updatedDateTime": "2020-01-01T00:00:00.0000000Z",
      "competitionIds" : [
         "00000000-0000-0000-0000-000000000000",
         "00000000-0000-0000-0000-000000000000"
      ],
      "platformIds" :[
         "00000000-0000-0000-0000-000000000000",
         "00000000-0000-0000-0000-000000000000",
         ],
      "athleteIds" : [
         "00000000-0000-0000-0000-000000000000",
         "00000000-0000-0000-0000-000000000000"
      ],
}
```