using System;
using System.Collections.Generic;

namespace EventsWeb.Models
{
    public partial class Documents
    {
        public int Iddocument { get; set; }
        public string Description { get; set; }
        public byte[] Blob { get; set; }
        public int Idregister { get; set; }

        public virtual Register IdregisterNavigation { get; set; }
    }
}
