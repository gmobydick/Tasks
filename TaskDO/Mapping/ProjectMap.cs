using TaskDO.Entities;

namespace TaskDO.Mapping
{
    public class ProjectMap : EntityMap<Project>
    {
        public ProjectMap()
        {
            HasMany(x => x.Tasks);
            HasManyToMany(x => x.Workers)
                .Cascade.SaveUpdate();
        }
    }
}
