namespace TaskDO.Entities
{
    public class TaskRecurrence : Task
    {
        //public virtual Task Task { get; set; }
        public virtual RecurrencePeriode RecurrencePeriode { get; set; }
        public virtual int SkipPeriod { get; set; }
        public virtual int NumberOfRepeats { get; set; }
    }
}