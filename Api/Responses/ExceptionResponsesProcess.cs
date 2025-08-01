using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AutoMapper;
using MediatR;
using Application.Commons.Exceptions;
using Application.Commons.Utils;


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

        private void HandleFormatValidationException(ExceptionContext context)
        {
            var exception = context.Exception as FormatValidationException;
            var errorsList = exception.Errors;
            var hasErrorsList = errorsList.Any();
            var details = hasErrorsList ? errorsList.GetValidationFormatFailures() : null;
            var response = new CustomExceptionResponse(
                message: null,
                exceptions: details
            );

            context.Result = new BadRequestObjectResult(response);
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
                case FormatValidationException:
                    HandleFormatValidationException(context);
                    break;
                default:
                    HandleInternalServerException(context);
                    break;
            }
        }
    }
}
