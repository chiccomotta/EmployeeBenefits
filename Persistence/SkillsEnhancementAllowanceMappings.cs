using Domain;
using FluentNHibernate.Mapping;

namespace Persistence
{
    public class SkillsEnhancementAllowanceMappings :
        SubclassMap<SkillsEnhancementAllowance>
    {
        public SkillsEnhancementAllowanceMappings()
        {
            DiscriminatorValue("SEA");
            Map(s => s.Entitlement);
            Map(s => s.RemainingEntitlement);
        }
    }
}
