using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alex.MVC.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}