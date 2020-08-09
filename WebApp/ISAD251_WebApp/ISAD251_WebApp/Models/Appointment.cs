using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251_WebApp.Models;
using Microsoft.Extensions.Configuration;

namespace ISAD251_WebApp.Models
{
    public partial class Appointment
    {
        private ISAD251_PWaughContext db = new ISAD251_PWaughContext();

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
