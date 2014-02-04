using TaskDO.Entities;

namespace TaskDO.Mapping
{
    public class WorkerMap : EntityMap<Worker>
    {
        public WorkerMap()
        {
            Map(x => x.Email);

            HasManyToMany(x => x.Tasks)
                .Inverse();

            HasManyToMany(x => x.TaskTimes)
                .Cascade.SaveUpdate();

            HasManyToMany(x => x.Projects)
                .Inverse();

        }
    }
}
