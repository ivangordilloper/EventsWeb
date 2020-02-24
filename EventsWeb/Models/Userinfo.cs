using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Userinfo
    {
        public int Iduser { get; set; }
        public int? Idstate { get; set; }
        public string City { get; set; }
        public DateTime? Dob { get; set; }
        public int? Idgender { get; set; }

        public virtual Gender IdgenderNavigation { get; set; }
        public virtual State IdstateNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
