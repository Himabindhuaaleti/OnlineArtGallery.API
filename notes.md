- dotnet ef migrations add AddImageUrlColumn
- dotnet ef database update

✅ Phase 1: Project Setup & Configuration
✅ Create ASP.NET Core Web API Project
✅ Install EF Core packages and set up GalleryContext
✅ Define all required models (User, ArtProduct, Order, OrderDetail, etc.)
✅ Configure DbContext in Program.cs with SQL Server connection string
🔐 Phase 2: Security Module (JWT Authentication)
✅ Implement user registration with password hashing (BCrypt)
✅ Implement login endpoint to return JWT token
✅ Configure JWT middleware & role-based authorization
✅ Add [Authorize] attributes for protected routes
🖼️ Phase 3: Art Work Management Module
✅ Get art by category
✅ Get art by ID or IDs
✅ Get product details for list of IDs (e.g., cart contents)
✅ Place order & save order details in DB
🧾 Phase 4: Optional (If Time Permits)
Generate and return invoice data when an order is placed
🔁 Phase 5: API Improvements & Best Practices
✅ Seeding database with dummy data
Input validation (DTOs, FluentValidation)
Logging & error handling
Use Automapper for DTO conversions
Organize folders: Controllers, Models, DTOs, Services, Helpers, etc.

If that sounds good, let’s begin now from Phase 1, and rework or enhance the components you’ve already built, where needed.

Would you like me to start by reviewing and refining your models and DbContext, or jump directly into authentication flow and role-based setup since we already have basic models?
