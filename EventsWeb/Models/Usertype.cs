using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Usertype
    {
        public Usertype()
        {
            User = new HashSet<User>();
        }

        public int Idusertype { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
