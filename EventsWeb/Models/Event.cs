using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Event
    {
        public Event()
        {
            Eventschedule = new HashSet<Eventschedule>();
        }

        public Guid Idevent { get; set; }
        public string Description { get; set; }
        public string Grade { get; set; }
        public int Ideventtype { get; set; }

        public virtual Eventtype IdeventtypeNavigation { get; set; }
        public virtual ICollection<Eventschedule> Eventschedule { get; set; }
    }
}
