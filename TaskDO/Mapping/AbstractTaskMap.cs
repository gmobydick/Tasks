using TaskDO.Entities;

namespace TaskDO.Mapping
{
    public abstract class AbstractTaskMap<T> : EntityMap<T> where T : Task
    {
        public AbstractTaskMap()
        {
            References(x => x.Project);
            HasManyToMany(x => x.Workers)
                .Cascade.SaveUpdate();

        }
    }
}
