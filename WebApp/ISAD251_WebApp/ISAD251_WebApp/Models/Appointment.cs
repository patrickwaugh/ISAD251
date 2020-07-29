using System;
using System.Collections.Generic;

namespace ISAD251_WebApp.Models
{
    public partial class Appointment
    {
        public int ApptId { get; set; }
        public string ApptTitle { get; set; }
        public DateTime ApptDate { get; set; }
        public string ApptLocation { get; set; }
        public TimeSpan? ApptDuration { get; set; }
        public string ApptNotes { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
