//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class alert_category
    {
        public alert_category()
        {
            this.alerts = new HashSet<Alert>();
        }
    
        public string Category { get; set; }
    
        public virtual ICollection<Alert> alerts { get; set; }
    }
}
