using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    public class CourseResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<ComponentResource> Elements { get; set; }
    }
}