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
    
    public partial class ProjectOwner
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    
        public virtual Project Project { get; set; }
    }
}