using System;
using TaskDO.Entities;

namespace TaskDO.Mapping
{
    public class TaskRecurrenceMap : AbstractTaskMap<TaskRecurrence>
    {
        public TaskRecurrenceMap()
        {
            Map(x => x.RecurrencePeriode).CustomType(typeof(Int32)).Not.Nullable();
            Map(x => x.SkipPeriod);
            Map(x => x.NumberOfRepeats);
        }
    }
}
