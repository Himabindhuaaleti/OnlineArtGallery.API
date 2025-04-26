
# 🖼️ Online Art Gallery - ASP.NET Core Web API Backend

This is the backend of the **Online Art Gallery** project built using ASP.NET Core Web API with Entity Framework Core and SQL Server.

---

## 🚀 How to Run This Project

### 1. Clone the Repository

```bash
git clone https://github.com/Himabindhuaaleti/OnlineArtGallery.API.git
cd OnlineArtGallery.API
```

---

### 2. Configure the Database

Make sure **SQL Server** is installed and running.

Edit the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "GalleryConnection": "Server=localhost;Database=OnlineArtGalleryDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> 🔧 **Note:** Replace `localhost` with your SQL Server name.  
> Example: `BAPC\SQLEXPRESS`

---

### 3. Install Dependencies

```bash
dotnet restore
```

---

### 4. Apply Migrations and Seed Data

If no migrations exist, run:

```bash
dotnet ef migrations add InitialCreate
```

Then update the database:

```bash
dotnet ef database update
```

✅ This will create the database and schema.

---

### 5. Run the API

```bash
dotnet run
```

Then open your browser and go to:

```
https://localhost:<port>/swagger/index.html
```

📘 Swagger will list all available API endpoints.

---

## ⚙️ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (or .NET 6)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Any IDE like **Visual Studio** or **VS Code**

---

## ✅ Features (Optional for Expansion)

- User authentication (JWT)
- Artwork management
- Order placement
- Invoice generation (optional)

---

## 📂 Structure (Optional for Adding Later)

Feel free to include folder structure, API routes, or setup diagrams if needed.

---

Let me know if you'd like to add a badge, screenshot, or contributors section!
