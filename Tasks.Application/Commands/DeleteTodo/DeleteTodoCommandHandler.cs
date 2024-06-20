using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Exceptions;
using Tasks.Domain.Entities;
using Tasks.Infrastructure.Data;

namespace Tasks.Application.Commands.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, Unit>
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteTodoCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FindAsync(request.Id) ?? throw new NotFoundException(nameof(TodoItem), request.Id);
            dbContext.TodoItems.Remove(todoItem);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
