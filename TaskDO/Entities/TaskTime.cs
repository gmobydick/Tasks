using System;

namespace TaskDO.Entities
{
    public class TaskTime : Entity
    {
        public virtual DateTime WorkedFrom { get; set; }
        public virtual DateTime WorkedTo { get; set; }

        public virtual Project Project { get; set; }
        public virtual Task Task { get; set; }
        public virtual Worker Worker { get; set; }

        public double WorkTime
        {
            get
            {
                TimeSpan timeSpan = WorkedTo.Subtract(WorkedFrom);
                int hours = timeSpan.Hours;
                if (timeSpan.Days > 0)
                    hours += timeSpan.Days*24;
                int minutes = timeSpan.Minutes;
                return (hours + (minutes/60.0));
            }
        }
    }
}