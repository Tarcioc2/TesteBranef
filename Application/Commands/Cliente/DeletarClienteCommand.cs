﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Cliente
{
    public class DeletarClienteCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
    }
}
