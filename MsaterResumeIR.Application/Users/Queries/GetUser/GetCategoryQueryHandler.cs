using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MsaterResumeIR.Application.Common;
using MsaterResumeIR.Domain.Interface;

namespace MsaterResumeIR.Application.Users.Queries.GetUser;

public class GetCategoryQueryHandler([FromKeyedServices("Dapper")] ICategoryRepository repCategory)
    : IRequestHandler<GetCategoryQuery, GetCategoryDto>
{
   
    private readonly ICategoryRepository _repCategory = repCategory;
   

    public async Task<GetCategoryDto> Handle(GetCategoryQuery request,
                                         CancellationToken cancellationToken = default)

    {

        var x=await _repCategory.GetByIdAsync(request.Id);
        return new GetCategoryDto(x.CategoryId, x.Name);
          
    }
     
}