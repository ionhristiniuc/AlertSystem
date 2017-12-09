using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Database;

namespace WebApp.ViewModels
{
    public class ObjectMapper
    {
        public static ComponentResource Convert(Element comp)
        {
            return new ComponentResource()
            {
                Id = comp.Id,
                TextContent = comp.TextContent,
                BinaryContent = comp.BinaryContent,
                CreateDate = comp.CreateDate,
                LastChangedDate = comp.LastChangedDate,
                CursId = comp.CursId,
                Type = comp.Type,
                Course = Convert(comp.course)
            };
        }

        public static CourseResource Convert(Course c)
        {
            return new CourseResource()
            {
                Id = c.Id,
                Name = c.Name,
                UniqueCode = c.UniqueCode
            };
        }
    }
}