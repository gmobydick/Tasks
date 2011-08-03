using System.Collections.Generic;

namespace TaskDO.Entities
{
    public class Task : Entity
    {
        public Task()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Workers = new List<Worker>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public virtual Project Project { get; set; }
        public virtual IList<Worker> Workers { get; set; }

        public virtual void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }
    }
}