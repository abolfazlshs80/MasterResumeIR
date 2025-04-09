using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MsaterResumeIR.Domain.Entities;
using MsaterResumeIR.Domain.Interface;

namespace MsaterResumeIR.Application.Category.Commands.CreateUser;

public class CreateCategoryCommandHandler([FromKeyedServices("EF")] ICategoryRepository repCategory,IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _repCategory = repCategory;

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {


        var Category = mapper.Map<Domain.Entities.Category>(request);
        await _repCategory.AddAsync(Category);

        //order
        //notifacation

        return Category.CategoryId;
    }
}