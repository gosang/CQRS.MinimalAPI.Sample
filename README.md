# CQRS Pattern (with Minimal API)

The CQRS pattern separates the handling of read and write operations in a software system. It achieves this by utilizing two distinct models:

- Queries: These models are exclusively concerned with reading data from the database. Queries retrieve data and return it to the client as Data Transfer Objects (DTOs). These DTOs are then displayed in the user interface.

- Commands: Commands focus on changing the state of an entity. They perform operations such as inserting, updating, or deleting data. Unlike queries, commands do not return data. Instead, they represent business operations and are always expressed in the imperative tense, instructing the application server to take specific actions.

By adopting CQRS, you can enhance performance, scalability, and security in your application, especially when dealing with complex workloads and asymmetrical read and write requirements. Remember that queries never modify the database, ensuring a clear separation of concerns between reading and writing operations.
