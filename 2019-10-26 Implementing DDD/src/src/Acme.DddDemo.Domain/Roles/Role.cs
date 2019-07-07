using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Values;
using Volo.Abp.Identity;
using Volo.Abp.Specifications;

namespace Acme.DddDemo.Roles
{
#if DISABLED

    public class GitRepository : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int StarCount { get; set; }

        public Collection<Issue> Issues { get; set; }
    }

    public class Issue : AggregateRoot<Guid>
    {
        public string Text { get; set; }

        public GitRepository Repository { get; set; }

        public Guid RepositoryId { get; set; }
    }

    public class Comment
    {

    }

    

    public class Role : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public Collection<UserRole> Users { get; set; }
    }

    public class User : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public Collection<UserRole> Roles { get; set; }
    }

    public class UserRole : ValueObject
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public UserRole()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }

        public class Organization
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //...
    }

    public class OrganizationUser
    {
        public Guid OrganizationId { get; set; }

        public Guid UserId { get; set; }

        public bool IsOwner { get; set; }

        //...
    }


    public class Issue //Aggregate Root
    {
        //...
        public bool IsLocked { get; private set; }
        public bool IsClosed { get; private set; }
        public IssueCloseReason? CloseReason { get; private set; }

        public void Lock()
        {
            if (!IsClosed)
            {
                throw new IssueStateException(
                    "Can not lock an open issue! Close it first."
                );
            }

            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public void Close(IssueCloseReason reason)
        {
            IsClosed = true;
            CloseReason = reason;
        }

        public void ReOpen()
        {
            if (IsLocked)
            {
                throw new IssueStateException(
                    "Can not open a locked issue! Unlock it first."
                );
            }

            IsClosed = false;
            CloseReason = null;
        }



        private Issue() { /* for deserialization */ }

        public Issue(
            Guid id,
            Guid repositoryId,
            string text,
            Guid? assignedUserId = null)
        {
            Id = id;
            RepositoryId = repositoryId;
            Text = Check.NotNullOrWhiteSpace(text, nameof(text));

            AssignedUserId = assignedUserId;
            Labels = new Collection<IssueLabel>();
        }
    }

    public class IssueStateException : Exception
    {
        public IssueStateException(string message)
        {
            throw new NotImplementedException();
        }
    }

    public enum IssueCloseReason
    {
        Fixed,
        WontFix,
        Canceled
    }

    public class IssueLabel
    {
    }

        public class Issue
    {
        public Guid Id { get; set; }
        public Guid RepositoryId { get; set; }
        public string Text { get; set; }

        public Guid? AssignedUserId { get; set; }
        public bool IsClosed { get; set; }
        public IssueCloseReason? CloseReason { get; set; }

        public Collection<IssueLabel> Labels { get; set; }

        private Issue() { /* for deserialization */ }

        public Issue(
            Guid id,
            Guid repositoryId,
            string text,
            Guid? assignedUserId = null)
        {
            Id = id;
            RepositoryId = repositoryId;
            Text = Check.NotNullOrWhiteSpace(text, nameof(text));

            AssignedUserId = assignedUserId;
            Labels = new Collection<IssueLabel>();
        }
    }

    public enum IssueCloseReason
    {
        Fixed,
        WontFix,
        Canceled
    }

    public class IssueLabel
    {
    }

     public class Issue
    {
        //...
        public Guid? AssignedUserId { get; private set; }

        public async Task AssignTo(User user, IUserIssueService userIssueService)
        {
            int currentIssueCount = await userIssueService.GetIssueCountAsync(user.Id);

            if (currentIssueCount >= 3) //Can be read from a configuration
            {
                throw new IssueAssignmentException(
                    "Can not assign more than 3 issues to a user!"
                );
            }

            AssignedUserId = user.Id;
        }
    }

    public class User : AggregateRoot<Guid>
    {
    }

    public class IssueAssignmentException : Exception
    {
        public IssueAssignmentException(string message)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserIssueService
    {
        Task<int> GetIssueCountAsync(Guid userId);
    }

    public enum IssueCloseReason
    {
        Fixed,
        WontFix,
        Canceled
    }
    

#endif

    public class IssueManager //Domain service
    {
        private readonly IIssueRepository _issueRepository;

        public IssueManager(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task Assign(Issue issue, User user)
        {
            var currentIssueCount = await _issueRepository.GetCountAsync(
                new IssueAssignmentSpecification(user)
            );

            if (currentIssueCount >= 3) //Can be read from a configuration
            {
                throw new IssueAssignmentException(
                    "Can not assign more than 3 issues to a user!"
                );
            }

            issue.AssignTo(user);
        }
    }

    public class User : AggregateRoot<Guid>
    {
    }

    public class Issue //Aggregate root
    {
        //...
        public bool IsClosed { get; set; }
        public Guid? AssignedUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastCommentTime { get; set; }
        public Guid? MileStoneId { get; set; }

        public bool IsInActive()
        {
            return new InActiveIssueSpecification()
                .IsSatisfiedBy(this);
        }

        internal void AssignTo(User user)
        {
            AssignedUserId = user.Id;
        }
    }

    public class IssueAssignmentException : Exception
    {
        public IssueAssignmentException(string message)
        {
            throw new NotImplementedException();
        }
    }

    //List<Issue> GetList(
    //    [CanBeNull] IssueQueryFilter filter
    //);

    public interface IIssueRepository
    {
        List<Issue> GetIssues(ISpecification<Issue> spec);
        Task<int> GetCountAsync(ISpecification<Issue> spec);
    }

    public class InActiveIssueSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression()
        {
            var daysAgo30 = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            return issue =>
                //Open
                !issue.IsClosed &&

                //Assigned to Nobody
                issue.AssignedUserId == null &&

                //Created 30+ days ago
                issue.CreationTime < daysAgo30 &&

                //No comment or the last comment was 30+ days ago
                (issue.LastCommentTime == null || issue.LastCommentTime < daysAgo30);
        }
    }

    public class IssueMilestoneSpecification : Specification<Issue>
    {
        private readonly Guid _mileStoneId;

        public IssueMilestoneSpecification(Guid mileStoneId)
        {
            _mileStoneId = mileStoneId;
        }

        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return issue => issue.MileStoneId == _mileStoneId;
        }
    }

    public class IssueAssignmentSpecification : Specification<Issue>
    {
        private readonly User _user;

        public IssueAssignmentSpecification(User user)
        {
            _user = user;
        }

        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return issue => issue.AssignedUserId == _user.Id;
        }
    }

    public class MyIssueService
    {
        private readonly IIssueRepository _issueRepository;

        public MyIssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public void Foo(Guid milestoneId)
        {
            var combinedSpec = new InActiveIssueSpecification()
                .And(new IssueMilestoneSpecification(milestoneId));

            var issues = _issueRepository.GetIssues(combinedSpec);
        }
    }
}
