# Project
ILVO Automatisation

## Automatisation

This folder contains automation functions for managing triggers and history tables in the database and creating CSV file with data from the database.

### History
The `History` class in the `History.cs` file is responsible for creating history tables for a specified entity type.

To create the history tables, you need to enter the following code in the console when running the project.

```csharp
history
```

### Triggers
The `Triggers` class in the `Triggers.cs` file is responsible for creating triggers for a specified entity type.

To create the triggers, you need to enter the following code in the console when running the project.

```csharp
trigger
```
### CSV
The `CSV` class in the `GenerateCSV.cs` file is responsible for creating CSV files from the database.

To create the CSV file, you need to enter the following code in the console when running the project.

```csharp
csv
```

## Data

### Constants

The `Constants` is used for the connection to the database.

In the folder `Data` add `Constants.cs`.

Add the code to the folder:
```csharp
public class Constants
{
    internal static string connectionString = "{connection string}";
}
```
### Test
In the folder `Data` is a folder `Test`, in this folder is the mock data created.

To create the mock data, you need to enter the following code in the console when running the project.

```csharp
mock
```

# Models
The `Models` folder contains classes representing the tables in the database. Each class corresponds to a table and defines its properties and relationships. These models are used to interact with the database and perform CRUD operations.

# Contributors
Steven D., Jarne S., Amy N.