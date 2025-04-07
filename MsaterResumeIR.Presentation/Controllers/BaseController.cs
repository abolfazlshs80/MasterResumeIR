﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MsaterResumeIR.Presentation.Controllers;

[Route("[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
