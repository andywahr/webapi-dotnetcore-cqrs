using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.WebApi.Application.Responses;
using Sample.WebApi.ServiceHost.Infrastructure;
using System;
using System.Net;

namespace Sample.WebApi.ServiceHost.Controllers
{
    /// <summary>
    /// Base Controller to standardized return message and error handling
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMediator Mediator { get; private set; }

        protected CallContext CallContext { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseController(IMediator serviceMediator, CallContext callContext)
        {
            Mediator = serviceMediator;
            CallContext = callContext;
        }

        public OkObjectResult OkResponse<T>(T response) where T : Application.Responses.Response
        {
            return Ok(GetResponse(response, HttpStatusCode.OK, true));
        }

        public BadRequestObjectResult InvalidParameter(string paramName, string errorId)
        {
            return BadRequestResponse(new ErrorResponse() { Message = $"Invalid Parmaeter {paramName}", ErrorId = errorId });
        }

        public BadRequestObjectResult BadRequestResponse<T>(T response) where T : Application.Responses.Response
        {
            return BadRequest(GetResponse(response, HttpStatusCode.BadRequest, false));
        }

        public BadRequestObjectResult NotFoundResponse<T>(T response) where T : Application.Responses.Response
        {
            return BadRequest(GetResponse(response, HttpStatusCode.NotFound, false));
        }

        private ResponseWrapper GetResponse<T>(T response, HttpStatusCode statusCode, bool? isSuccess = null) where T : Application.Responses.Response
        {
            if ( !isSuccess.HasValue )
            {
                isSuccess = !response?.Successfull ?? false;
            }

            if (isSuccess.Value)
            {
                return new ResponseWrapper<T>()
                {
                    Result = response,
                    IsSuccess = true,
                    StatusCode = statusCode,
                    TransactionId = CallContext.TransactionId
                };
            }
            else
            {
                return new ResponseWrapper<ErrorResponse>()
                {
                    Result = new ErrorResponse()
                    {
                        ErrorId = response.ErrorId,
                        Message = response.Message,
                    },
                    IsSuccess = false,
                    StatusCode = statusCode,
                    TransactionId = CallContext.TransactionId
                };
            }
        }

        public IActionResult WrapResult<T>(T response, Func<Response, ObjectResult> successResult = null, Func<Response, ObjectResult> failedResult = null) where T : Application.Responses.Response
        {
            if (successResult == null)
            {
                successResult = OkResponse;
            }

            if (failedResult == null)
            {
                failedResult = BadRequestResponse;
            }

            if (response.Successfull)
            {
                return successResult(response);
            }
            else
            {
                return failedResult(response);
            }
        }
    }


}

