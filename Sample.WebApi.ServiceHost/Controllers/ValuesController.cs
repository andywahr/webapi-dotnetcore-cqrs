using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.WebApi.Application.Requests.Values;
using Sample.WebApi.Application.Responses;
using Sample.WebApi.ServiceHost.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WebApi.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        public ValuesController(IMediator mediator, CallContext callContext) : base(mediator, callContext)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ValuesResponse>), 200), ProducesResponseType(typeof(ResponseWrapper<ErrorResponse>), 404)]

        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            ValuesResponse response = await Mediator.Send(new GetAllValuesRequest(), cancellationToken);
            return WrapResult(response);
        }

        [HttpPut]
        [Route("update/{value}")]
        [ProducesResponseType(typeof(ResponseWrapper<CommandResponse>), 200), ProducesResponseType(typeof(ResponseWrapper<ErrorResponse>), 400)]
        public async Task<IActionResult> update(int value, CancellationToken cancellationToken)
        {
            if (value > 1000)
            {
                return InvalidParameter("Invalid value", "ERRORID#1");
            }

            CommandResponse response = await Mediator.Send(new UpdateValueRequest() { NewValue = value }, cancellationToken);
            return WrapResult(response);

        }
    }
}
