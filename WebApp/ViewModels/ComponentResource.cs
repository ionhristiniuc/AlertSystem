using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    public class ComponentResource
    {
        public int Id { get; set; }
        public string TextContent { get; set; }
        public byte[] BinaryContent { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime LastChangedDate { get; set; }
        public int CursId { get; set; }
        public string Type { get; set; }

        public virtual CourseResource Course { get; set; }
    }
}