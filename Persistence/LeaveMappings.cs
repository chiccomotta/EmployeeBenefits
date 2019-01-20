using Domain;
using FluentNHibernate.Mapping;

namespace Persistence
{
    public class LeaveMappings : SubclassMap<Leave>
    {
        public LeaveMappings()
        {
            DiscriminatorValue("LVE");
            Map(l => l.AvailableEntitlement);
            Map(l => l.RemainingEntitlement);
            Map(l => l.Type);
        }
    }
}