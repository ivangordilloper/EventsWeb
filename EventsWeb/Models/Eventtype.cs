using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Eventtype
    {
        public Eventtype()
        {
            Event = new HashSet<Event>();
        }

        public int Ideventtype { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
