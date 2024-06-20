using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Commands.DeleteTodo
{
    public class DeleteTodoCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
