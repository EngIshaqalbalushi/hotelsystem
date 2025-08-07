
# 🏨 Hotel Room Management System

![Hotel Logo](https://cdn-icons-png.flaticon.com/512/235/235861.png)

A **console-based hotel management system** built with C#, Entity Framework Core, and SQL Server. This project is a fully layered application demonstrating repository and service pattern, ideal for learning clean architecture.

---

## 📦 Technologies Used

- **C#** (.NET 6+)
- **Entity Framework Core**
- **SQL Server / LocalDB**
- **Repository & Service Layer**
- **Console UI**

---

## 🌟 Features

| Feature                        | Description                                      |
|-------------------------------|--------------------------------------------------|
| ✅ Add & View Rooms            | Create rooms with daily rate & availability     |
| ✅ Add & View Guests           | Register and list guests                        |
| ✅ Make Reservations           | Book rooms for guests and calculate cost        |
| ✅ Leave Reviews               | Guests can rate and review rooms                |
| ✅ Search & Delete             | Cancel reservations, search by guest, etc.      |
| ✅ Console UI                  | Menu-driven interaction                         |
| ✅ EF Core Migrations          | Code-first approach with auto schema updates    |

---

## 🧱 Folder Structure

```bash
HotelSystem/
│
├── Models/               # Room, Guest, Reservation, Review
├── Data/                 # DbContext (HotelContext.cs)
├── Repository/           # IRepository<T>, GuestRepository, etc.
├── Services/             # Business logic services
├── Migrations/           # Auto-generated EF Core migrations
├── Program.cs            # Main console entry point
└── README.md             # This file
```

---

## 🖼 Screenshots

### 🟢 Console Menu

![Menu](https://i.imgur.com/5H8YxgJ.png)

### 🟢 Add Room Example

![Add Room](https://i.imgur.com/YaRkaLM.png)

### 🟢 View Reservations

![Reservations](https://i.imgur.com/Vng3Lzz.png)

---

## 🚀 Getting Started

### ⚙️ Prerequisites

- .NET 6 SDK
- Visual Studio or VS Code
- SQL Server (Express or LocalDB)

### 💻 Run the App

1. Clone the repo:

```bash
git clone https://github.com/your-username/HotelSystem.git
cd HotelSystem
```

2. Install packages (via NuGet or CLI):

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

3. Create the database:

```bash
Add-Migration InitialCreate
Update-Database
```

4. Run the project:

```bash
dotnet run
```

---

## 💡 Example Entities

### 🛏 Room

```csharp
public class Room {
    public int RoomNumber { get; set; }
    public double DailyRate { get; set; }
    public bool IsReserved { get; set; }
}
```

### 👤 Guest

```csharp
public class Guest {
    public string GuestName { get; set; }
}
```

---

## 🙌 Author & License

Made with 💙 by **Your Name**  
License: MIT

---

## 📬 Contact

Have questions or suggestions? Reach out at: [you@example.com](mailto:you@example.com)
