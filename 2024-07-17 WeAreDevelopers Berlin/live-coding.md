# Workshop Live Coding Notes

## Create a new ABP solution

* Use the `new` command to create a new ABP solution:
  ````bash
  abp new Acme.BookStore -t app
  ````

* Open the solution in your IDE.
* Run the `DbMigrator` application to create the database.

* Run the `install-libs` command if needed:
  ````bash
  abp install-libs
  ````

* Run the application!

## The Domain Layer

* Create a `Book` class in the `Domain` project:
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

* Create a `BookType` enum in the `Domain.Shared` project:
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

* s
