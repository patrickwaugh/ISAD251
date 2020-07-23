using System;
using System.Collections.Generic;

namespace ISAD251_Referral.Models
{
    public partial class Deadline
    {
        public int DeadlineId { get; set; }
        public string DeadlineTitle { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string DeadlineNotes { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
