# BoundlessBooks

An Asp.net MVC Web App to order books online
A user can register and then login to the website
View books and click on more details and view more details on a book
Can add books to a cart
Can checkout and make purchase
Can search by book title

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

## Getting Started

To set up this project locally, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/Ahmedi95/BoundlessBooks
   ```

2. Navigate to the project directory:

   ```bash
   cd your-repo
   ```

3. **Database Setup:**

   - Inside the `root/database` directory, you'll find an SQL file (`BoundlessBooksDB.sql`). Import this file into your preferred SQL database (e.g., MySQL, SQL Server).

   - Update the connection string in `appsettings.json`:

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=YourDatabaseName;User=YourUsername;Password=YourPassword;"
     }
     ```

     Replace `YourDatabaseName`, `YourUsername`, and `YourPassword` with your actual database details.

4. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

5. Build and run the project:

   ```bash
   dotnet build
   dotnet run
   ```

6. Open your browser and navigate to [http://localhost:PORT_NUMBER].
