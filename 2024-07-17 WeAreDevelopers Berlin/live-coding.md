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

## EF Core Mapping / Database Operations

* Add the `Book` entity to the `BookStoreDbContext` class (in the `EntityFrameworkCore` project):
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

## Create the Application Service

* Create `IBookAppService` in the `Application.Contracts` project (in the `Books` folder):

  ````csharp
  using System;
  using Volo.Abp.Application.Dtos;
  using Volo.Abp.Application.Services;
  
  namespace Acme.BookStore.Books;
  
  public interface IBookAppService :
      ICrudAppService< //Defines CRUD methods
          BookDto, //Used to show books
          Guid, //Primary key of the book entity
          PagedAndSortedResultRequestDto, //Used for paging/sorting
          CreateUpdateBookDto> //Used to create/update a book
  {
  
  }
  ````

* Create `BookAppService` in the `Application` project (in the `Books` folder):
  ````csharp
  using System;
  using Volo.Abp.Application.Dtos;
  using Volo.Abp.Application.Services;
  using Volo.Abp.Domain.Repositories;
  
  namespace Acme.BookStore.Books;
  
  public class BookAppService :
      CrudAppService<
          Book, //The Book entity
          BookDto, //Used to show books
          Guid, //Primary key of the book entity
          PagedAndSortedResultRequestDto, //Used for paging/sorting
          CreateUpdateBookDto>, //Used to create/update a book
      IBookAppService //implement the IBookAppService
  {
      public BookAppService(IRepository<Book, Guid> repository)
          : base(repository)
      {
  
      }
  }
  ````

* Create `BookDto` in the `Application.Contracts` project (in the `Books` folder):
  ````csharp
  using System;
  using Volo.Abp.Application.Dtos;
  
  namespace Acme.BookStore.Books;
  
  public class BookDto : AuditedEntityDto<Guid>
  {
      public string Name { get; set; }
      public BookType Type { get; set; }
      public DateTime PublishDate { get; set; }
      public float Price { get; set; }
  }
  ````

* Create `BookDto` in the `Application.Contracts` project (in the `Books` folder):
  ````csharp
  using System;
  using System.ComponentModel.DataAnnotations;
  
  namespace Acme.BookStore.Books;
  
  public class CreateUpdateBookDto
  {
      [Required]
      [StringLength(128)]
      public string Name { get; set; } = string.Empty;
  
      [Required]
      public BookType Type { get; set; } = BookType.Undefined;
  
      [Required]
      [DataType(DataType.Date)]
      public DateTime PublishDate { get; set; } = DateTime.Now;
  
      [Required]
      public float Price { get; set; }
  }
  ````

* Add the following mappings into `BookStoreApplicationAutoMapperProfile` class (in the `Application` project):

  ````csharp
  CreateMap<Book, BookDto>();
  CreateMap<CreateUpdateBookDto, Book>();
  ````

* .
