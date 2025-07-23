using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;


namespace Api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        private IMediator _mediator;

        private IMapper _mapper;

        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IMapper? Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
