using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MsaterResumeIR.Application.Common;
using MsaterResumeIR.Domain.Entities;
using MsaterResumeIR.Domain.Interface;

namespace MsaterResumeIR.Application.Users.Commands.CreateUser;

public class CreateCategoryCommandHandler([FromKeyedServices("EF")] ICategoryRepository repCategory)
    : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _repCategory = repCategory;

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {
        var Category = new Category
        {
            Name = request.Name,
        };
        await _repCategory.AddAsync(Category);

        //order
        //notifacation

        return Category.CategoryId;
    }
}