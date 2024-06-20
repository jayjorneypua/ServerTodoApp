using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Models;
using Tasks.Infrastructure.Data;

namespace Tasks.Application.Queries.GetTodos
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ApplicationDbContext dbContext;

        public GetTodosQueryHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<TodoItemDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.TodoItems.Select(t => new TodoItemDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
            }).ToListAsync(cancellationToken);
               
        }
    }
}
