﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class ClienteUpdatedEvent
    {
        public Guid Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Porte { get; set; }
    }
}
