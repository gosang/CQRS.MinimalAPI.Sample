# CQRS Pattern (with Minimal API)

The CQRS (Command Query Responsibility Segregation) pattern separates the handling of read and write operations in a software system. It achieves this by utilizing two distinct models:

- Queries: These models are exclusively concerned with reading data from the database. Queries retrieve data and return it to the client as Data Transfer Objects (DTOs). These DTOs are then displayed in the user interface.

- Commands: Commands focus on changing the state of an entity. They perform operations such as inserting, updating, or deleting data. Unlike queries, commands do not return data. Instead, they represent business operations and are always expressed in the imperative tense, instructing the application server to take specific actions.

By adopting CQRS, you can enhance performance, scalability, and security in your application, especially when dealing with complex workloads and asymmetrical read and write requirements. Remember that queries never modify the database, ensuring a clear separation of concerns between reading and writing operations.

# Benefits of CQRS

When designing your architecture using CQRS principles, you unlock several advantages that can significantly improve your system’s performance, maintainability, and scalability. Here are the key benefits:

- Separation of Concerns
  - By separating the read and write sides, CQRS promotes a clear distinction between different aspects of your application.
    - The read model focuses on providing efficient query capabilities for retrieving data. It is typically simpler and optimized for read-heavy workloads.
    - The write model handles complex business logic, ensuring that domain-specific rules are enforced during data modification.
- Independent Scaling
  - CQRS allows you to scale the read and write workloads independently.
    - For read-heavy scenarios, you can allocate additional resources to the read side without affecting the write side, and vice versa.
    - This flexibility minimizes lock contentions and ensures optimal resource utilization.
- Optimized Data Schemas
  - On the read side, you can design a schema specifically tailored for efficient querying.
    - Conversely, the write side can have a schema optimized for handling updates and maintaining data consistency.
    - This separation enables better performance and adaptability to different use cases.
- Enhanced Security
  - With CQRS, you can enforce fine-grained access controls.
    - Only authorized domain entities (such as specific services or users) are allowed to perform writes on the data.
    - This granular control enhances security and reduces the risk of unauthorized modifications.
- Simpler Queries
  - Application queries can avoid complex joins by leveraging materialized views stored in the read database.
    - These precomputed views provide denormalized data, making queries more straightforward and efficient.
    - As a result, your application can respond faster to user requests.

# Implementation
This project demonstrates the use of Minimal API pattern using the MediatR library, 
SQLite database and EFCore8 as an ORM framework. Minimal APIs in ASP.NET Core offer a streamlined approach to building small microservices and HTTP APIs. 
By leveraging ASP.NET Core’s hosting and routing capabilities, it allows creating fully functional APIs with 
minimal code. This approach eliminates the need for complex scaffolding and unnecessary dependencies, 
making it easier and faster to develop robust APIs.

In summary, adopting CQRS principles empowers your architecture with better scalability, maintainability, and security. By separating concerns and optimizing data handling, you can build robust systems that meet the demands of modern applications.
