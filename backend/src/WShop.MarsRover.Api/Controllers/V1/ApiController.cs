using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WShop.MarsRover.Api.Controllers.V1
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IMediator _mediator;
        //private IMapper _mapper;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();        
    }
}
