using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands
{
    public interface ICommand<TResponse>: IRequest<TResponse>
    {
    }
}
