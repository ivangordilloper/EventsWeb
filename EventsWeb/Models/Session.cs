using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Session
    {
        public Guid Idsession { get; set; }
        public int Iduser { get; set; }
        public DateTime Lastaccess { get; set; }

        public virtual User IduserNavigation { get; set; }
    }
}
