using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeKeeper.WebApi.Models.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool Invoiced { get; set; }
        public int TotalProjectTime { get; set; }
    }
}