# Project Title: Meditation Course API 🧘

> A robust backend system for a meditation course application, built with .NET and Clean Architecture, focusing on maintainability and scalability.

## 🌟 Key Features

* User Authentication & Authorization with JWT.
* Course & Lesson Management (CRUD).
* User Progress Tracking.
* RESTful API endpoints for all functionalities.

## 🛠️ Technology Stack

* **Backend:** .NET 8, ASP.NET Core Web API
* **Architecture:** Clean Architecture, SOLID Principles, Repository Pattern
* **Database:** Microsoft SQL Server, Entity Framework Core
* **Authentication:** JSON Web Tokens (JWT)

## 🏛️ Architecture

This project strictly follows the principles of **Clean Architecture** to ensure a clear separation of concerns, making the system easy to test, maintain, and scale.

*(Optional but highly recommended: Add a simple diagram of your architecture here. You can draw it using tools like diagrams.net and embed the image)*

![Architecture Diagram]((https://res.cloudinary.com/dqwxudyzu/image/upload/v1749444868/hight-level-design_ebxs5e.png))

## 🚀 Getting Started

### Prerequisites

* .NET 8 SDK
* Microsoft SQL Server
* Visual Studio 2022 or VS Code

### Installation & Setup

1.  **Clone the repository:**
    ```sh
    git clone [https://github.com/Vohoangtuanhdhtdm/meditation-course-api.git](https://github.com/Vohoangtuanhdhtdm/meditation-course-api.git)
    ```
2.  **Configure the database connection:**
    * Open `appsettings.json` in the `.API` project.
    * Update the `DefaultConnection` string with your SQL Server credentials.
3.  **Apply database migrations:**
    ```sh
    cd meditation-course-api/Khoa_Hoc_Thien_Dinh.API
    dotnet ef database update
    ```
4.  **Run the application:**
    ```sh
    dotnet run
    ```
The API will be available at `https://localhost:5001/swagger`.

## 📸 Screenshots

*(Add 1-2 screenshots of your Swagger UI or Postman requests here to make it visual!)*

![Swagger UI](link_to_your_swagger_screenshot.png)
