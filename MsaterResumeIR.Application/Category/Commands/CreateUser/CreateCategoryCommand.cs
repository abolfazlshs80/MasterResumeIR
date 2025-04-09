using AutoMapper;
using MediatR;
using MsaterResumeIR.Application.Category.Queries.GetUser;
using MsaterResumeIR.Application.Common.Mappings;

namespace MsaterResumeIR.Application.Category.Commands.CreateUser;

public record CreateCategoryCommand(string Name) : IRequest<int>, IMapFrom<Domain.Entities.Category>
{

    public CreateCategoryCommand() : this("") { }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, CreateCategoryCommand>()
            .ReverseMap();
    }
}