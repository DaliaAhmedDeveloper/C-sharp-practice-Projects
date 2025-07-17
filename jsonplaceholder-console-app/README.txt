# 🖥️ JSONPlaceholder Console App in C#

A C# **console application** that interacts with the [JSONPlaceholder](https://jsonplaceholder.typicode.com/) REST API, demonstrating core .NET programming concepts and best practices.

---

## 🚀 Features

- 🔍 Search for users by **email**.
- 👤 Display user profile details.
- 📝 View posts by a specific user.
- ➕ Simulate adding new posts.
- 🔁 Continuously prompt user for valid input.
- 🌐 Uses asynchronous HTTP requests with `HttpClient`.

---

## 🧠 Concepts Practiced

This project demonstrates key **Object-Oriented Programming (OOP)** and C# concepts:

| Concept              | Description / Usage Example                          |
|----------------------|------------------------------------------------------|
| **Encapsulation**     | Private fields with public accessors in models       |
| **Inheritance**       | Base structure for controllers/services              |
| **Polymorphism**      | Generic methods in JSON deserialization              |
| **Singleton Pattern** | `User.Instance()` ensures one shared object          |
| **Async/Await**       | Asynchronous API calls (non-blocking)                |
| **Generics**          | Deserialize any model using `JsonHelper<T>`          |
| **Validation**        | Input validation using `Func<>` delegates            |
| **Separation of Concerns** | Models, Services, Helpers, and Controllers split |

---
## 📁 Project Structure

/App
├── Models // User, Post, etc.
├── Services // Logic to communicate with API
├── Controllers // Entry logic for each feature
├── Helpers // Input validation and JSON tools
├── Classes // Base Classes For Inheritance
├── Interfaces // Icontroller Interface
└── Program.cs // Main entry point


---

## ▶️ Getting Started

### ✅ Prerequisites

- [.NET SDK 7.0 or above](https://dotnet.microsoft.com/)
- Visual Studio or VS Code

### 🛠️ How to Run

```bash
git clone https://github.com/your-username/jsonplaceholder-console-app.git
cd jsonplaceholder-console-app
dotnet build
dotnet run
