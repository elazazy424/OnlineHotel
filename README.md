**Online Hotel Reservation System**

**Project Overview:**
The Online Hotel Reservation System is a comprehensive MVC project built using the SOLID principles and structured with a 3-tier architecture. This project aims to provide a robust and scalable solution for managing hotel reservations, ensuring a seamless experience for both the hotel staff and guests.

**Technologies Used:**
- **ASP.NET Core MVC:** For the web application framework to build dynamic web pages.
- **Entity Framework Core:** For ORM (Object-Relational Mapping) to interact with the database.
- **SQL Server:** As the database management system.
- **Dependency Injection:** To achieve loose coupling and enhance the testability and maintenance of the application.
- **Task-based Asynchronous Pattern (TAP):** To improve the scalability and responsiveness of the application.

**Architecture:**
The application is designed using the 3-tier architecture, ensuring a clear separation of concerns and promoting maintainability and scalability.

1. **Presentation Layer:**
   - This is the topmost layer of the application and consists of the views and controllers.
   - **Views:** Responsible for displaying the user interface, created using Razor syntax.
   - **Controllers:** Handle user input, interact with the business logic layer, and determine the appropriate view to render.

2. **Business Logic Layer (BLL):**
   - Contains the core functionality and business rules of the application.
   - Implements various services and business operations.
   - Ensures that the business logic is decoupled from the presentation and data access layers.

3. **Data Access Layer (DAL):**
   - Manages all data-related operations.
   - Uses Entity Framework Core to interact with the SQL Server database.
   - Provides a clean interface for accessing and manipulating data, ensuring that the rest of the application is abstracted from the complexities of data storage.

**Key Features:**
- **User Registration and Authentication:** Utilizes ASP.NET Core Identity for secure user registration and authentication.
- **Hotel Management:** Allows hotel staff to manage room availability, pricing, and other details.
- **Reservation System:** Enables guests to search for available rooms, make reservations, and receive confirmation emails.
- **Email Notifications:** Implements an email sender utility using asynchronous methods to send confirmation and notification emails.

**SOLID Principles Applied:**
- **Single Responsibility Principle (SRP):** Each class in the system has a single responsibility, making the codebase easier to understand and maintain.
- **Open/Closed Principle (OCP):** The system is designed to be extendable without modifying existing code, facilitating future enhancements.
- **Liskov Substitution Principle (LSP):** Ensures that derived classes can be substituted for their base classes without affecting the correctness of the program.
- **Interface Segregation Principle (ISP):** The system uses specific interfaces to ensure that classes only need to implement the methods they actually use.
- **Dependency Inversion Principle (DIP):** High-level modules do not depend on low-level modules; both depend on abstractions, promoting loose coupling.

**Project Highlights:**
- **Email Sender Utility:** The `EmailSender` class implements the `IEmailSender` interface to provide asynchronous email sending functionality. This promotes adherence to the Dependency Inversion Principle and makes the email functionality easily testable and replaceable.
- **Separation of Concerns:** The clear division of the application into three layers (Presentation, Business Logic, and Data Access) ensures that each layer can be developed, tested, and maintained independently.

**Conclusion:**
The Online Hotel Reservation System is a well-architected application that leverages modern software development practices and principles. By adhering to the SOLID principles and employing a 3-tier architecture, the project ensures high maintainability, scalability, and ease of future enhancements.


