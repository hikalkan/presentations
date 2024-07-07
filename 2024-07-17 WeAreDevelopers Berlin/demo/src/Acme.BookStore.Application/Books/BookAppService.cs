using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books;

[Authorize(BookStorePermissions.Books)]
public class BookAppService : ApplicationService, IBookAppService
{
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookAppService(IRepository<Book, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
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
    }

    [Authorize(BookStorePermissions.Books_Create)]
    public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        var book = ObjectMapper.Map<CreateUpdateBookDto, Book>(input);
        await _bookRepository.InsertAsync(book);
        
        if (input.Name == "test")
        {
            throw new UserFriendlyException("Test books are not allowed!");
        }

        return ObjectMapper.Map<Book, BookDto>(book);
    }

    [Authorize(BookStorePermissions.Books_Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _bookRepository.DeleteAsync(id);
    }
}