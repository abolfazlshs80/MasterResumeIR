using Microsoft.AspNetCore.Mvc;
using MsaterResumeIR.Application.Users.Commands.CreateUser;
using MsaterResumeIR.Application.Users.Queries.GetUser;

namespace MsaterResumeIR.Presentation.Controllers;

public class CategoryController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoryDto>> GetCategory([FromQuery] GetCategoryQuery query)
     => await Mediator.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
       => await Mediator.Send(command);
}
