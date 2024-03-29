﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public byte[] Password { get; set; }
        public string? AutoLoginGUID { get; set; }
        public DateTime? AutoLoginGUIDExpires { get; set; }
        public List<FinancialChange> FinancialChanges { get; set; }
    }
}
