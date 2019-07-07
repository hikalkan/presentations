using System.Collections.Generic;
using System.Linq;
using Acme.DddDemo.EntityFrameworkCore;
using Acme.DddDemo.Roles;
using Volo.Abp.Specifications;

namespace Acme.DddDemo
{
    public class EfCoreIssueRepository: IIssueRepository
    {
        private readonly DddDemoDbContext _dbContext;
        public EfCoreIssueRepository(DddDemoDbContext dbContext) { _dbContext = dbContext; }
        
        public List<Issue> GetIssues(ISpecification<Issue> spec)
        {
            return _dbContext.Issues
                .Where(spec.ToExpression())
                .ToList();
        }
    }
}
