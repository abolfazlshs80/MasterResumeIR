using MediatR;

namespace MsaterResumeIR.Application.Users.Commands.CreateUser;

public record CreateCategoryCommand : IRequest<int>
{

    public string Name { get; set; }
}