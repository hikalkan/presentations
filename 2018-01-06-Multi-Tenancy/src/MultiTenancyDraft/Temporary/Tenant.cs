using System;

namespace MultiTenancyDraft.Temporary
{
    public class Tenant
    {
        public Guid Id { get; }
        public string Name { get; }

        public Tenant(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}