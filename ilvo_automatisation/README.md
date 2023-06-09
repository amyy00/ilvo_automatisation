# Project Name
ILVO Automatisation


# Description
ILVO Automatisation is a project that provides functionalities for connecting to a database, generating mock data, automating triggers, and generating CSV files.


# Getting Started
## Prerequisites
- Before running the project, make sure you have the following:


# .NET Core SDK link to download
## Installation
1. Clone the repository: git clone https://github.com/your-username/ilvo-automatisation.git
2. Navigate to the project directory: cd ilvo-automatisation


# Connecting to Database
To connect to the database, you need to provide the connection string in a Constants.cs file. Follow these steps:

1. Create a file named Constants.cs in the ilvo_automatisation.Data folder.
2. Add the following code to the Constants.cs file:
    ```csharp
    public class Constants
    {
        internal static string connectionString = "{connection string}";
    }
    ```
3. Replace {connection string} with the actual connection string for your database.


# Mock Data
The project includes a functionality to generate mock data for the database. To use this feature, follow these steps:

1. Run the program.
2. Enter the command mock when prompted.
3. The program will fill the database with mock data.

# Automatisation
The project provides automatisation features for triggers. To automate triggers for a specific entity type, follow these steps:

1. Run the program.
2. Enter the command trigger when prompted.
3. The program will automate triggers for each entity type in the database.


# CSV
The project allows generating CSV files from the database. To generate a CSV file, follow these steps:

1. Run the program.
2. Enter the command csv when prompted.
3. The program will generate a CSV file based on the database tables and save it to the default output path.



# Usage
1. Run the program.
2. Enter one of the following commands when prompted:
  - csv: Generate a CSV file from the database.
  - mock: Fill the database with mock data.
  - trigger: Automate triggers for the database.
  - history: Automate history for the database.
  - exit: Close the program.

# Contributors
Jarne S., Amy N., Steven D.