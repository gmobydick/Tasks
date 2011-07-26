using TaskDO.Entities;

namespace TaskDO.Mapping
{
    public class TaskTimeMap : EntityMap<TaskTime>
    {
        public TaskTimeMap()
        {
            Map(x => x.WorkedFrom);
            Map(x => x.WorkedTo);
            References(x => x.Project);
            References(x => x.Task);
            References(x => x.Worker);
        }
    }
}
