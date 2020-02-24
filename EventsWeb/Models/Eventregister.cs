using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Eventregister
    {
        public long Ideventregister { get; set; }
        public int Ideventschedule { get; set; }
        public int Iduser { get; set; }
        public string Evaluation { get; set; }
        public string Comments { get; set; }

        public virtual Eventschedule IdeventscheduleNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
