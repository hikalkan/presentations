using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acme.DddDemo.EntityFrameworkCore;
using Acme.DddDemo.Roles;

namespace Acme.DddDemo
{
    public class EfCoreIssueRepository: IIssueRepository
    {
        private readonly DddDemoDbContext _dbContext;
        public EfCoreIssueRepository(DddDemoDbContext dbContext) { _dbContext = dbContext; }

        public List<Issue> GetInActiveIssues()
        {
            var daysAgo30 = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            return _dbContext.Issues
                .Where(i =>

                    //Open
                    !i.IsClosed &&

                    //Assigned to Nobody
                    i.AssignedUserId == null &&

                    //Created 30+ days ago
                    i.CreationTime < daysAgo30 &&

                    //No comment or the last comment was 30+ days ago
                    (i.LastCommentTime == null || i.LastCommentTime < daysAgo30)

                ).ToList();
        }
    }
}
