using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MsaterResumeIR.Domain.Interface;

namespace MsaterResumeIR.Application.Category.Queries.GetUser;

public class GetCategoryQueryHandler([FromKeyedServices("Dapper")] ICategoryRepository repCategory, IMapper mapper)
    : IRequestHandler<GetCategoryQuery, GetCategoryDto>
{

  

    public async Task<GetCategoryDto> Handle(GetCategoryQuery request,
                                         CancellationToken cancellationToken = default)

    {

        var x=await repCategory
            .GetByIdAsync(request.Id);
        return  mapper.Map<GetCategoryDto>(x);
          
    }
     
}