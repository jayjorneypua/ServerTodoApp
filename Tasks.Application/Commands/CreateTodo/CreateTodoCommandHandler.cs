using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Entities;
using Tasks.Infrastructure.Data;

namespace Tasks.Application.Commands.CreateTodo
{
    public class CreateTodoCommandHandler: IRequestHandler<CreateTodoCommand, int>
    {
        private readonly ApplicationDbContext dbContext;

        public CreateTodoCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem { Title = request.Title };
            await dbContext.TodoItems.AddAsync(todoItem);
            await dbContext.SaveChangesAsync(cancellationToken); 
            return todoItem.Id;
        }
    }
}
