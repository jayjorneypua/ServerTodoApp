using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Exceptions;
using Tasks.Domain.Entities;
using Tasks.Infrastructure.Data;

namespace Tasks.Application.Commands.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Unit>
    {
        private readonly ApplicationDbContext dbContext;

        public UpdateTodoCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FindAsync(request.Id) ?? throw new NotFoundException(nameof(TodoItem), request.Id);
            todoItem.Title = request.Title;
            todoItem.IsCompleted = request.IsCompleted;
            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
