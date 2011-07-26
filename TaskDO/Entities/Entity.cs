using System;
using System.ComponentModel.DataAnnotations;

namespace TaskDO.Entities
{
    /// <summary>
    /// Basis class for all entities
    /// </summary>
    public abstract class Entity
    {
        [Display(Name = "ID")]
        // ReSharper disable UnusedAutoPropertyAccessor.Local
            public virtual int Id { get; private set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Local

        public virtual int Version { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 80 characters")]
        [Display(Name = "Name")]
        [Editable(false)] //Not working as expected.
            public virtual string Name { get; set; }

        [StringLength(100, ErrorMessage = "Description can maximum be 100 characters")]
        [Display(Name = "Description")]
        public virtual string Description { get; set; }

        public virtual DateTime? CreatedAt { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
        public virtual string UpdatedBy { get; set; }
    }
}