using System;
using System.Collections.Generic;

namespace ISAD251_WebApp.Models
{
    public partial class User
    {
        public User()
        {
            Appointment = new HashSet<Appointment>();
            Deadline = new HashSet<Deadline>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsParent { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Deadline> Deadline { get; set; }
    }
}
