# Workshop Live Coding Notes

## Create a new ABP solution

* Use the `new` command to create a new ABP solution:
  ````bash
  abp new Acme.BookStore -t app
  ````

* Open the solution in your IDE
* Run the `DbMigrator` application to create the database

* Run the `install-libs` command if needed:
  ````bash
  abp install-libs
  ````

* Run the application
* Explore the application UI and explain the fundamental concepts (roles, users, responsive UI, login, register,...)
* Explore the solution structure

## The Domain Layer

* Create a `Book` class in the `Domain` project (create a `Books` folder and add inside it):
  ````csharp
  using System;
  using Volo.Abp.Domain.Entities.Auditing;
  
  namespace Acme.BookStore.Books;
  
  public class Book : AuditedAggregateRoot<Guid>
  {
      public string Name { get; set; }
      public BookType Type { get; set; }
      public DateTime PublishDate { get; set; }
      public float Price { get; set; }
  }
  ````

* Create a `BookType` enum in the `Domain.Shared` project (create a `Books` folder and add inside it):
  ````csharp
  namespace Acme.BookStore.Books;
  
  public enum BookType
  {
      Undefined,
      Adventure,
      Biography,
      Dystopia,
      Fantastic,
      Horror,
      Science,
      ScienceFiction,
      Poetry
  }
  ````

## EF Core Mapping Database Operations

* Add the `Book` entity to the `BookStoreDbContext` class:
  ````csharp
  public DbSet<Book> Books { get; set; }
  ````

* Add the following code into the `OnModelCreating` method of the `BookStoreDbContext` class:
  ````csharp
  builder.Entity<Book>(b =>
  {
  	b.ToTable(BookStoreConsts.DbTablePrefix + "Books", BookStoreConsts.DbSchema);
  	b.Property(x => x.Name).IsRequired().HasMaxLength(128);
  });
  ````

* Add a new database migration:
  ````csharp
  dotnet ef migrations add Created_Book_Entity
  ````

* Run the `DbMigrator` application again to update the database
