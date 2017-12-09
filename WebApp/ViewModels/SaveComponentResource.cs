using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels
{
    public class SaveComponentResource
    {
        public int Id { get; set; }
        public string TextContent { get; set; }
        public byte[] BinaryContent { get; set; }
        public int CursId { get; set; }
        public string Type { get; set; }
    }
}