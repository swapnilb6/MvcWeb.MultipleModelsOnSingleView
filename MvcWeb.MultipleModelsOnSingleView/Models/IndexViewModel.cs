using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.MultipleModelsOnSingleView.Models
{
    public class IndexViewModel
    {
        public List<Employee> employees { get; set; }

        public List<Student> students { get; set; }
    }
}