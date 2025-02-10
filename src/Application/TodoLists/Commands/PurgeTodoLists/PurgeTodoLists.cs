using MarmindSample.Application.Common.Interfaces;
using MarmindSample.Application.Common.Security;
using MarmindSample.Domain.Constants;

namespace MarmindSample.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeTodoListsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        _context.TodoLists.RemoveRange(_context.TodoLists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
