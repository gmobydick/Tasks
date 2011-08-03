using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskDO.Entities;

namespace TaskMVC.Areas.Admin.Models
{
    public class ProjectModel
    {
        public IEnumerable<Project> AllProjects { get; set; }
        public Project SelectedProject { get; set; }
    }

    public class TaskModel
    {
        
    }
}