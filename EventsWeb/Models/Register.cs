using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Register
    {
        public Register()
        {
            Documents = new HashSet<Documents>();
        }

        public int Idregister { get; set; }
        public bool Isvalid { get; set; }
        public int? Iduser { get; set; }

        public virtual User IduserNavigation { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
