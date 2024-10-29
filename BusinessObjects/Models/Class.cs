using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Class
    {
        public Class()
        {
            UserClasses = new HashSet<UserClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}
