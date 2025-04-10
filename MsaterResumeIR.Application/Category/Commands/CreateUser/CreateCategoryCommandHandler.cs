using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MsaterResumeIR.Domain.Entities;
using MsaterResumeIR.Domain.Interface;

namespace MsaterResumeIR.Application.Category.Commands.CreateUser;
//[FromKeyedServices("EF")] ICategoryRepository repCategory
public class CreateCategoryCommandHandler(IRepository<Domain.Entities.Category> repCategory, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, int>
{
  

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {


        var Category = mapper.Map<Domain.Entities.Category>(request);
        await repCategory.AddAsync(Category);

        //order
        //notifacation

        return Category.CategoryId;
    }
}