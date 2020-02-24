using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class State
    {
        public State()
        {
            Userinfo = new HashSet<Userinfo>();
        }

        public int Idstate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Userinfo> Userinfo { get; set; }
    }
}
