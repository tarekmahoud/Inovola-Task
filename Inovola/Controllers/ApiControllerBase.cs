﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inovola.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
