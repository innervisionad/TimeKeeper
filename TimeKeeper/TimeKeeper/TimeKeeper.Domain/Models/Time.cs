//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeKeeper.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Time
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsInvoiced { get; set; }
    
        public virtual Project Project { get; set; }
    }
}