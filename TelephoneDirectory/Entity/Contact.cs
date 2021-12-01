using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int PersonId { get; set; }
    }
}
