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
    
    public partial class Alert
    {
        public Alert()
        {
            this.UserAlertQueue = new HashSet<UserAlertQueue>();
        }


        public int Id { get; set; }
        public string Subject { get; set; }
        public string Short_text { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> Notify_time { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Source_id { get; set; }
        public string Search_key { get; set; }
        public string Address { get; set; }
        public string Alert_category { get; set; }
        public Nullable<int> Raiting { get; set; }
        public string Link { get; set; }
        public Nullable<System.DateTime> InsertedOn { get; set; }
    
        public virtual Source Source { get; set; }
        public virtual User User { get; set; }
        public virtual AlertCategory AlertCategory { get; set; }
        public virtual ICollection<UserAlertQueue> UserAlertQueue { get; set; }
    }
}
