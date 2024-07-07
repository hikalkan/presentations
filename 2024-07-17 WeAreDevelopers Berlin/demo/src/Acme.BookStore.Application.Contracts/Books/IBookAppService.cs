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