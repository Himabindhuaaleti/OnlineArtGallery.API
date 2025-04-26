# 🖼️ Online Art Gallery - ASP.NET Core Web API Backend

## 🚀 How to Run This Project

### 1. Clone the Repository

git clone OnlineArtGallery.API -- clone repo
cd OnlineArtGallery.API

### 2. Configure the Database

Make sure SQL Server is installed and running.

Edit the connection string in `appsettings.json`:

{
"ConnectionStrings": {
"GalleryConnection": "Server=localhost;Database=OnlineArtGalleryDb; Trusted_Connection=True;TrustServerCertificate=True;"
}
}

#### NOTE:- Change localhost to your server name (example:- BAPC\\SQLEXPRESS)

### 3. Install Dependencies

`dotnet restore`

### 4. Apply Migrations and Seed Data

If no migration exists:

`dotnet ef migrations add InitialCreate`

Then update the database:

`dotnet ef database update`

✅ The database and schema will be created.

### 5. Run the API

`dotnet run`

Then open your browser and go to:

`/swagger/index.html`

Swagger will list all available endpoints.

### ⚙️ Requirements

.NET 8 SDK (or 6 if you're using it)

SQL Server (2019 or later)

Any IDE like VS Code
