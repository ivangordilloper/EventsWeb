using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Eventschedule
    {
        public Eventschedule()
        {
            Eventregister = new HashSet<Eventregister>();
        }

        public int Ideventschedule { get; set; }
        public Guid Idevent { get; set; }
        public int Iduser { get; set; }
        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }

        public virtual Event IdeventNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
        public virtual ICollection<Eventregister> Eventregister { get; set; }
    }
}
