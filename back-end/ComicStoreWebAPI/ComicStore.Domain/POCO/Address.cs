﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComicStore.Domain.POCO
{
    public class Address
    {
        public string Line1 { get; set; }
        public int Number { get; set; }
        public string Line2 { get; set; }        
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
