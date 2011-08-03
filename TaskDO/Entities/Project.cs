using System.Collections.Generic;

namespace TaskDO.Entities
{
    public class Project : Entity
    {
        public Project()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Tasks = new List<Task>();
            Workers = new List<Worker>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public virtual IList<Task> Tasks { get; set; }
        public virtual IList<Worker> Workers { get; set; }

        public virtual void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public virtual void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }
    }
}