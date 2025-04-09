using MediatR;

namespace MsaterResumeIR.Application.Category.Queries.GetUser;

public record GetCategoryQuery(int Id) : IRequest<GetCategoryDto>;