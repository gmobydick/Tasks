using System.Collections.Generic;

namespace TaskDO.Entities
{
    public class Worker : Entity
    {
        public Worker()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Tasks = new List<Task>();
            TaskTimes = new List<TaskTime>();
            Projects = new List<Project>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public virtual string Email { get; set; }

        public virtual IList<Task> Tasks { get; set; }
        public virtual IList<TaskTime> TaskTimes { get; set; }
        public virtual IList<Project> Projects { get; set; }


        public virtual void AddHoursTask(TaskTime taskTime)
        {
            TaskTimes.Add(taskTime);
        }
    }
}