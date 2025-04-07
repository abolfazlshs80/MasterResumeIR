using MediatR;
using MsaterResumeIR.Application.Common;
using MsaterResumeIR.Domain.Entities;

namespace MsaterResumeIR.Application.Users.Commands.CreateUser;

public class CreateCategoryCommandHandler(IApplicationDbContext dbContext)
    : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {
        var Category = new Category
        {
            Name = request.Name,
        };
        
        _dbContext.Category.Add(Category);
        await _dbContext.SaveChangesAsync(cancellationToken);
        //order
        //notifacation

        return Category.CategoryId;
    }
}