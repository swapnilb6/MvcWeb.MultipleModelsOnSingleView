using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.MultipleModelsOnSingleView.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}