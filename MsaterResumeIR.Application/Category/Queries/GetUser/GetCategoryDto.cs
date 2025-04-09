using AutoMapper;
using MsaterResumeIR.Application.Common.Mappings;
using MsaterResumeIR.Domain.Entities;

namespace MsaterResumeIR.Application.Category.Queries.GetUser;

public record GetCategoryDto(int CategoryId, string Name) : IMapFrom<Domain.Entities.Category>
{
    public GetCategoryDto() : this(0, "") { }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, GetCategoryDto>()
          .ReverseMap();
    }
}
