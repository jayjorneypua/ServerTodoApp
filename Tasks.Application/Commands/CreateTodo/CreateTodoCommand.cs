using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Commands.CreateTodo
{
    public class CreateTodoCommand: IRequest<int>
    {
        public string Title { get; set; }
    }
}
