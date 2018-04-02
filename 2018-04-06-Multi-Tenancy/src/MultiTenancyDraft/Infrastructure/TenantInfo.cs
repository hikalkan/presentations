using System;
using System.Threading;

namespace MultiTenancyDraft.Infrastructure
{
    public class TenantInfo
    {
        public static TenantInfo Current
        {
            get => _current.Value;
            set => _current.Value = value;
        }
        private static readonly AsyncLocal<TenantInfo> _current = new AsyncLocal<TenantInfo>();

        public Guid Id { get; set; }

        public string Name { get; set; }

        public TenantInfo(Guid id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public static IDisposable Change(TenantInfo tenantInfo)
        {
            var oldValue = Current;
            Current = tenantInfo;
            return new DisposeAction(() =>
            {
                Current = oldValue;
            });
        }

        public override string ToString()
        {
            return $"[Tenant] Id = {Id}, Name = {Name}";
        }
    }
}
