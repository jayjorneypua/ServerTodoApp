using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Exceptions;
using Tasks.Application.Models;
using Tasks.Domain.Entities;
using Tasks.Infrastructure.Data;

namespace Tasks.Application.Queries.GetTodoById
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoItemDto>
    {
        private readonly ApplicationDbContext dbContext;

        public GetTodoByIdQueryHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TodoItemDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FindAsync(request.Id) ?? throw new NotFoundException(nameof(TodoItem), request.Id);
            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted, 
            };
        }
    }
}
