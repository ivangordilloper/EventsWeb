using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Userinfo = new HashSet<Userinfo>();
        }

        public int Idgender { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Userinfo> Userinfo { get; set; }
    }
}
