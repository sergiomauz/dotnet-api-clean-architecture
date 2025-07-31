using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AutoMapper;
using MediatR;


namespace Api.Responses
{
    public class ExceptionResponsesProcess : ExceptionFilterAttribute
    {
        private IMediator _mediator;
        private IMapper _mapper;

        private void HandleInternalServerException(ExceptionContext context)
        {
            var response = new CustomExceptionResponse(
                message: "Internal Server Error, contact with a system administrator."
            );

            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }

        private void HandleMediatorNullException(ExceptionContext context)
        {
            var response = new CustomExceptionResponse(
                message: "Server can not process the request. Request body is malformed."
            );

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        private void HandleNotImplementedException(ExceptionContext context)
        {
            var response = new CustomExceptionResponse(
                message: "Internal Server Error, contact with a system administrator."
            );

            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }

        public override void OnException(ExceptionContext context)
        {
            _mediator = context.HttpContext.RequestServices.GetService<IMediator>();
            _mapper = context.HttpContext.RequestServices.GetService<IMapper>();

            switch (context.Exception)
            {
                case ArgumentNullException
                    when context.Exception.Source.Equals("MediatR"):
                    HandleMediatorNullException(context);
                    break;
                case NotImplementedException:
                    HandleNotImplementedException(context);
                    break;
                default:
                    HandleInternalServerException(context);
                    break;
            }
        }
    }
}
