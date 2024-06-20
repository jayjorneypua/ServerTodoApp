using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Models;

namespace Tasks.Application.Queries.GetTodos
{
    public class GetTodosQuery: IRequest<IEnumerable<TodoItemDto>>
    {
    }
}
