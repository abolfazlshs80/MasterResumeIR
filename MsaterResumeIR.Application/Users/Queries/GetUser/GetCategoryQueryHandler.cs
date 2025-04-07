using MediatR;
using Microsoft.EntityFrameworkCore;
using MsaterResumeIR.Application.Common;

namespace MsaterResumeIR.Application.Users.Queries.GetUser;

public class GetCategoryQueryHandler(IApplicationDbContext dbContext)
    : IRequestHandler<GetCategoryQuery, GetCategoryDto>
{
    private readonly IApplicationDbContext _dbContext = dbContext;
   

    public async Task<GetCategoryDto> Handle(GetCategoryQuery request,
                                         CancellationToken cancellationToken = default)
      => await _dbContext.Category
                   .Select(x => new GetCategoryDto(x.CategoryId, x.Name))
                   .FirstOrDefaultAsync(x => x.CategoryId == request.Id, cancellationToken);
}