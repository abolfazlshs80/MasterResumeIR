using MediatR;

namespace MsaterResumeIR.Application.Users.Queries.GetUser;

public record GetCategoryQuery(int Id) : IRequest<GetCategoryDto>;