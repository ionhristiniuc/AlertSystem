using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    public class AlertModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Short_text { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> Notify_time { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Source_id { get; set; }
        public string Address { get; set; }

        public AlertModel(Database.Alert alert)
        {
            Id = alert.Id;
            Subject = alert.Subject;
            Short_text = alert.Short_text;
            Text = alert.Text;
            Notify_time = alert.Notify_time;
            User_id = alert.User_id;
            Source_id = alert.Source_id;
            Address = alert.Address;
        }
    }
}
