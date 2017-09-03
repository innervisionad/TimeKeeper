using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeKeeper.WebApi.Models.DTO
{
    public class TimeDTO
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
       
        public DateTime Date { get; set; }
        [Required]
        public DateTime TimeStart { get; set; }
        [Required]
        public DateTime TimeEnd { get; set; }
        public int HoursSpent { get; set; }
        public string Description { get; set; }
        public bool IsInvoiced { get; set; }

    }
}