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

* Run the application and open the Books page.

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

* Create a `CreateModal` Razor Page under the `Pages/Books` folder.

* Replace `CreateModal.cshtml.cs` content with the following:
  ````csharp
  using System.Threading.Tasks;
  using Acme.BookStore.Books;
  using Microsoft.AspNetCore.Mvc;
  
  namespace Acme.BookStore.Web.Pages.Books
  {
      public class CreateModal : BookStorePageModel
      {
          [BindProperty]
          public CreateUpdateBookDto Book { get; set; }
  
          private readonly IBookAppService _bookAppService;
  
          public CreateModal(IBookAppService bookAppService)
          {
              _bookAppService = bookAppService;
          }
  
          public void OnGet()
          {
              Book = new CreateUpdateBookDto();
          }
  
          public async Task<IActionResult> OnPostAsync()
          {
              await _bookAppService.CreateAsync(Book);
              return NoContent();
          }
      }
  }
  ````

* Replace `CreateModal.cshtml` with the following content:
  ````html
  @page
  @using Acme.BookStore.Web.Pages.Books
  @using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Modal
  @model CreateModal
  
  @{
      Layout = null;
  }
  
  <abp-dynamic-form abp-model="Book" asp-page="/Books/CreateModal">
      <abp-modal>
          <abp-modal-header title="New Book"></abp-modal-header>
          <abp-modal-body>
              <abp-form-content />
          </abp-modal-body>
          <abp-modal-footer buttons="@(AbpModalButtons.Cancel|AbpModalButtons.Save)"></abp-modal-footer>
      </abp-modal>
  </abp-dynamic-form>
  ````

* Add a "New Book" button to the Index page's header (Replace the `abp-card-header`):
  ````html
  <abp-card-header>
      <abp-row>
          <abp-column size-md="_6">
              <abp-card-title>Books</abp-card-title>
          </abp-column>
          <abp-column size-md="_6" class="text-end">
              <abp-button id="NewBookButton"
                          text="New Book"
                          icon="plus"
                          button-type="Primary"/>
          </abp-column>
      </abp-row>
  </abp-card-header>
  ````

* Add the following code under the `dataTable` configuration in the `Index.cshtml.js` file:
  ````js
  var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
  
  createModal.onResult(function () {
      dataTable.ajax.reload();
  });
  
  $('#NewBookButton').click(function (e) {
      e.preventDefault();
      createModal.open();
  });
  ````

* Add the following definition to the `columnDefs` list, before the `Name` column in `Index.cshtml.js`:
  ````js
  {
      title: 'Actions',
      rowAction: {
          items:
              [
                  {
                      text: 'Delete',
                      confirmMessage: function (data) {
                          return 'Are you sure to delete the book: ' + data.record.name;
                      },
                      action: function (data) {
                          acme.bookStore.books.book
                              .delete(data.record.id)
                              .then(function() {
                                  abp.notify.info('Successfully deleted the book');
                                  dataTable.ajax.reload();
                              });
                      }
                  }
              ]
      }
  },
  ````

## Add Integration Tests

* Create a `BookStoreDataSeederTestContributor` class in the `Domain.Tests` project:
  ````csharp
  using System;
  using System.Threading.Tasks;
  using Acme.BookStore.Books;
  using Volo.Abp.Data;
  using Volo.Abp.DependencyInjection;
  using Volo.Abp.Domain.Repositories;
  
  namespace Acme.BookStore;
  
  public class BookStoreDataSeederTestContributor
      : IDataSeedContributor, ITransientDependency
  {
      private readonly IRepository<Book, Guid> _bookRepository;
  
      public BookStoreDataSeederTestContributor(IRepository<Book, Guid> bookRepository)
      {
          _bookRepository = bookRepository;
      }
  
      public async Task SeedAsync(DataSeedContext context)
      {
          if (await _bookRepository.GetCountAsync() > 0)
          {
              return;
          }
  
          await _bookRepository.InsertAsync(
              new Book
              {
                  Name = "1984",
                  Type = BookType.Dystopia,
                  PublishDate = new DateTime(1949, 6, 8),
                  Price = 19.84f
              },
              autoSave: true
          );
  
          await _bookRepository.InsertAsync(
              new Book
              {
                  Name = "The Hitchhiker's Guide to the Galaxy",
                  Type = BookType.ScienceFiction,
                  PublishDate = new DateTime(1995, 9, 27),
                  Price = 42.0f
              },
              autoSave: true
          );
      }
  }
  ````

* Create `BookAppService_Tests` class in the `Application.Tests` project (in a `Book` folder):
  ````csharp
  using System;
  using System.Linq;
  using System.Threading.Tasks;
  using Shouldly;
  using Volo.Abp.Application.Dtos;
  using Volo.Abp.Modularity;
  using Volo.Abp.Validation;
  using Xunit;
  
  namespace Acme.BookStore.Books;
  
  public abstract class BookAppService_Tests<TStartupModule> : BookStoreApplicationTestBase<TStartupModule>
      where TStartupModule : IAbpModule
  {
      private readonly IBookAppService _bookAppService;
  
      protected BookAppService_Tests()
      {
          _bookAppService = GetRequiredService<IBookAppService>();
      }
  
      [Fact]
      public async Task Should_Get_List_Of_Books()
      {
          //Act
          var result = await _bookAppService.GetListAsync(
              new PagedAndSortedResultRequestDto()
          );
  
          //Assert
          result.TotalCount.ShouldBeGreaterThan(0);
          result.Items.ShouldContain(b => b.Name == "1984");
      }
      
      [Fact]
      public async Task Should_Create_A_Valid_Book()
      {
          //Act
          var result = await _bookAppService.CreateAsync(
              new CreateUpdateBookDto
              {
                  Name = "New test book 42",
                  Price = 10,
                  PublishDate = DateTime.Now,
                  Type = BookType.ScienceFiction
              }
          );
  
          //Assert
          result.Id.ShouldNotBe(Guid.Empty);
          result.Name.ShouldBe("New test book 42");
      }
      
      [Fact]
      public async Task Should_Not_Create_A_Book_Without_Name()
      {
          var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
          {
              await _bookAppService.CreateAsync(
                  new CreateUpdateBookDto
                  {
                      Name = "",
                      Price = 10,
                      PublishDate = DateTime.Now,
                      Type = BookType.ScienceFiction
                  }
              );
          });
  
          exception.ValidationErrors
              .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
      }
  }
  ````

* Create `EfCoreBookAppService_Tests` in the `EntityFrameworkCore.Tests` project (in the `EntityFrameworkCore/Applications` folder):
  ````csharp
  using Acme.BookStore.Books;
  using Xunit;
  
  namespace Acme.BookStore.EntityFrameworkCore.Applications;
  
  [Collection(BookStoreTestConsts.CollectionDefinitionName)]
  public class EfCoreBookAppService_Tests : BookAppService_Tests<BookStoreEntityFrameworkCoreTestModule>
  {
  
  }
  ````

* Run the tests and see the result.

* Remove `Assert.ThrowsAsync` from `Should_Not_Create_A_Book_Without_Name` to see it throws exception and the test fails.

## Authorization: Adding Permissions

* Change the `BookStorePermissions` class (in the `Application.Contracts` project) like that:
  ````csharp
  namespace Acme.BookStore.Permissions;
  
  public static class BookStorePermissions
  {
      public const string GroupName = "BookStore";
      
      public const string Books = GroupName + ".Books";
      public const string Books_Create = GroupName + ".Books.Create";
      public const string Books_Delete = GroupName + ".Books.Delete";
  }
  ````

* Change the `BookStorePermissionDefinitionProvider` class (in the `Application.Contracts` project) like that:
  ````csharp
  using Volo.Abp.Authorization.Permissions;
  using Volo.Abp.Localization;
  
  namespace Acme.BookStore.Permissions;
  
  public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
  {
      public override void Define(IPermissionDefinitionContext context)
      {
          var myGroup = context.AddGroup(BookStorePermissions.GroupName);
          
          var booksPermission = myGroup.AddPermission(BookStorePermissions.Books, new FixedLocalizableString("Books page"));
          booksPermission.AddChild(BookStorePermissions.Books_Create, new FixedLocalizableString("Create a new book"));
          booksPermission.AddChild(BookStorePermissions.Books_Delete, new FixedLocalizableString("Delete books"));
      }
  }
  ````

* Show the permission management dialog: A new Books tab is automatically added.

* Add the following lines to the `BookAppService` constructor:
  ````csharp
  GetPolicyName = BookStorePermissions.Books;
  GetListPolicyName = BookStorePermissions.Books;
  CreatePolicyName = BookStorePermissions.Books_Create;
  DeletePolicyName = BookStorePermissions.Books_Delete;
  ````

* Add `RequirePermissions` extension method call on the `ApplicationMenuItem` definition:
  ````csharp
  context.Menu.AddItem(
      new ApplicationMenuItem(
          "BooksStore",
          "Books",
          url: "/Books",
          icon: "fa fa-book"
      ).RequirePermissions(BookStorePermissions.Books)
  );
  ````

* Replace the `Index.cshtml` content with the following (to hide the Book Create button):
  ````html
  @page
  @using Acme.BookStore.Permissions
  @using Microsoft.AspNetCore.Authorization
  @inject IAuthorizationService AuthorizationService
  @model Acme.BookStore.Web.Pages.Books.Index
  
  @section scripts
  {
      <abp-script src="/Pages/Books/Index.cshtml.js" />
  }
  
  <abp-card>
      <abp-card-header>
          <abp-row>
              <abp-column size-md="_6">
                  <abp-card-title>Books</abp-card-title>
              </abp-column>
              <abp-column size-md="_6" class="text-end">
                  @if (await AuthorizationService.IsGrantedAsync(BookStorePermissions.Books_Create))
                  {
                      <abp-button id="NewBookButton"
                                  text="New Book"
                                  icon="plus"
                                  button-type="Primary"/>
                  }
              </abp-column>
          </abp-row>
      </abp-card-header>
      <abp-card-body>
          <abp-table striped-rows="true" id="BooksTable"></abp-table>
      </abp-card-body>
  </abp-card>
  ````

* Add the following line into the Delete action definition in the `Index.cshtml.js` file:
  ````js
  visible: abp.auth.isGranted('BookStore.Books.Delete'),
  ````

## Audit Logging

* See `[AbpAuditLogs]` and `[AbpAuditLogActions]` tables to show that ABP saves all the actions.
* Add `[Audited]` on top of the `Book` entity and show it starts saving all changes for that entity.
  * See `[AbpEntityChanges]` and `[AbpEntityPropertyChanges]` database table records.

## Implement the BookAppService Manually

* Replace `IBookAppService` with the following content:
  ````csharp
  using System;
  using System.Threading.Tasks;
  using Volo.Abp.Application.Dtos;
  using Volo.Abp.Application.Services;
  
  namespace Acme.BookStore.Books;
  
  public interface IBookAppService : IApplicationService
  {
      Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input);
  
      Task<BookDto> CreateAsync(CreateUpdateBookDto input);
  
      Task DeleteAsync(Guid id);
  }
  ````

* Replace `BookAppService` with the following content:
  ````csharp
  using System;
  using System.Threading.Tasks;
  using Volo.Abp.Application.Dtos;
  
  namespace Acme.BookStore.Books;
  
  public class BookAppService : ApplicationService, IBookAppService
  {
      public async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
      {
          throw new NotImplementedException();
      }
  
      public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
      {
          throw new NotImplementedException();
      }
  
      public async Task DeleteAsync(Guid id)
      {
          throw new NotImplementedException();
      }
  }
  ````

* Inject `IRepository<Book, Guid>` to `BookAppService` (add new field and constructor):
  ````csharp
  private readonly IRepository<Book, Guid> _bookRepository;
  
  public BookAppService(IRepository<Book, Guid> bookRepository)
  {
      _bookRepository = bookRepository;
  }
  ````

* Implement the `GetListAsync` method:
  ````csharp
  var books = await _bookRepository.GetPagedListAsync(
      input.SkipCount,
      input.MaxResultCount,
      input.Sorting ?? nameof(Book.Name)
  );
  
  var totalBookCount = await _bookRepository.GetCountAsync();
  
  return new PagedResultDto<BookDto>
  {
      TotalCount = totalBookCount,
      Items = ObjectMapper.Map<List<Book>, List<BookDto>>(books)
  };
  ````

* Implement the `CreateAsync` method:
  ````csharp
  var book = ObjectMapper.Map<CreateUpdateBookDto, Book>(input);
  await _bookRepository.InsertAsync(book);
  return ObjectMapper.Map<Book, BookDto>(book);
  ````

* Implement the `DeleteAsync` method:
  ````csharp
  await _bookRepository.DeleteAsync(id);
  ````

* Add `[Authorize(BookStorePermissions.Books)]` to the `BookAppService` class.

* Add `[Authorize(BookStorePermissions.Books_Create)]` to the `CreateAsync` method.

* Add `[Authorize(BookStorePermissions.Books_Delete)]` to the `DeleteAsync` method.

## Repositories

* Show the https://docs.abp.io/en/abp/latest/Repositories document
  * Standard methods
  * LINQ over a repository
  * Bulk operations
  * Soft-delete entities
  * Custom repositories

## Unit of Work & Exception Handling

* Add the following code inside the `CreateAsync` method, just after the `_bookRepository.InsertAsync` call:
  ````csharp
  if (input.Name == "test")
  {
      throw new UserFriendlyException("Test books are not allowed!");
  }
  ````

  * Unit of work system cancelled the database transaction and `UserFriendlyException` shows the given message to the user!

## Caching Entities

* Inject `IEntityCache<Book, Guid> bookCache` to the `BookAppService` class.

* Add a new `GetAsync` method:

* ```csharp
  public async Task<BookDto> GetAsync(Guid id)
  {
      var book = await _bookCache.GetAsync(id);
      return ObjectMapper.Map<Book, BookDto>(book);
  }
  ```

* Add the following line into `ConfigureServices` method of the `BookStoreApplicationModule` class:
  ````csharp
  context.Services.AddEntityCache<Book, Guid>();
  ````

* Switch to caching a DTO instead of the entity:

  * Change `AddEntityCache<Book, Guid>()` to `AddEntityCache<Book, BookDto, Guid>()`
  * Inject `IEntityCache<BookDto, Guid>` in `BookAppService` (instead `IEntityCache<Book, Guid>`)
  * Change `GetAsync` method body to: `return await _bookCache.GetAsync(id);`

## Convert Book entity to Multi-Tenant

* Implement `IMultiTenant` interface for the `Book` entity
  ````csharp
  public Guid? TenantId { get; set; }
  ````

* Create a new database migration:
  ````csharp
  dotnet ef migrations add "Book_MultiTenant"
  ````

* Update the database:
  ````csharp
  dotnet ef database update
  ````

## Localization

* Add `"Books": "Books"` into `en.json` file under the `Domain.Shared` project's `Localization/BookStore` folder.
* Add `"Books": "Kitaplar"` into `tr.json` file under the `Domain.Shared` project's `Localization/BookStore` folder.
* Add `@inject IStringLocalizer<BookStoreResource> L` to `Index.cshtml` file.
* Replace `Books` title with `@L["Books"]` usage.
* Show `abp.localization.localize('Books');` in the developer console.
