using Microsoft.AspNetCore.Mvc;
using MsaterResumeIR.Application.Users.Commands.CreateUser;
using MsaterResumeIR.Application.Users.Queries.GetUser;

namespace MsaterResumeIR.Presentation.Controllers;

public class CategoryController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoryDto>> GetCategory()
    {
        GetCategoryQuery query=new GetCategoryQuery (1);
        var model = await Mediator.Send(query);
        return Content(model.Name);
    }

    [HttpGet]
    public async Task<ActionResult<GetCategoryDto>> CreateCategory()
    {
        CreateCategoryCommand query = new CreateCategoryCommand { Name="test"+new Random().Next(1111,9999)};
        var model = await Mediator.Send(query);
        return Content("created");
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
       => await Mediator.Send(command);
}
