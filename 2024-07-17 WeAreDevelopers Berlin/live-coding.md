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

## Create the  Data Transfer Objects

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

## Test the API

* Open `/swagger`, show the Book API, create a book.

* Test the API on the developer console, get list of the books:
  ````javascript
  acme.bookStore.books.book.getList({})
      .done(function (result) { console.log(result); });
  ````

* Test the API on the developer console, create a new book:
  ````js
  acme.bookStore.books.book.create({
          name: 'Foundation',
          type: 7,
          publishDate: '1951-05-24',
          price: 21.5
      }).then(function (result) {
          console.log('successfully created the book with id: ' + result.id);
      });
  ````

## Build the User Interface

* Create a `Books` folder under the `Pages` folder, then create a new `Index` Razor Page under it:
  ````html
  @page
  @model Acme.BookStore.Web.Pages.Books.Index
  
  <h2>Books</h2>
  ````

* Add new menu item (inside the `BookStoreMenuContributor` class):
  ````csharp
  context.Menu.AddItem(
      new ApplicationMenuItem(
          "BooksStore",
          "Books",
          url: "/Books",
          icon: "fa fa-book"
      )
  );
  ````

* Replace the `Index.cshtml` content with the following:
  ````html
  @page
  @model Acme.BookStore.Web.Pages.Books.Index
  
  @section scripts
  {
      <abp-script src="/Pages/Books/Index.js" />
  }
  
  <abp-card>
      <abp-card-header>
          <h2>Books</h2>
      </abp-card-header>
      <abp-card-body>
          <abp-table striped-rows="true" id="BooksTable"></abp-table>
      </abp-card-body>
  </abp-card>
  ````

* Create `Index.cshtml.js` file with the following content:
  ````js
  $(function () {
      var dataTable = $('#BooksTable').DataTable(
          abp.libs.datatables.normalizeConfiguration({
              serverSide: true,
              paging: true,
              order: [[1, "asc"]],
              searching: false,
              scrollX: true,
              ajax: abp.libs.datatables.createAjax(acme.bookStore.books.book.getList),
              columnDefs: [
                  {
                      title: 'Name',
                      data: "name"
                  },
                  {
                      title: 'Type',
                      data: "type"
                  },
                  {
                      title: 'Publish Date',
                      data: "publishDate",
                      render: function (data) {
                          return luxon
                              .DateTime
                              .fromISO(data, {
                                  locale: abp.localization.currentCulture.name
                              }).toLocaleString();
                      }
                  },
                  {
                      title: 'Price',
                      data: "price"
                  },
                  {
                      title: 'Creation Time', data: "creationTime",
                      render: function (data) {
                          return luxon
                              .DateTime
                              .fromISO(data, {
                                  locale: abp.localization.currentCulture.name
                              }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                      }
                  }
              ]
          })
      );
  });
  ````

  

* .



### The Book List Page



### Creating a new book



### Deleting a book

