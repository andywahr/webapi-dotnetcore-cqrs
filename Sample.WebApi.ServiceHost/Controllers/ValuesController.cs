using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.WebApi.Application.Requests.Values;
using Sample.WebApi.Application.Responses;
using Sample.WebApi.Application.Services;
using Sample.WebApi.ServiceHost.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WebApi.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        private readonly IOCEntry _entry;

        public ValuesController(IMediator mediator, CallContext callContext, IOCEntry entry) : base(mediator, callContext)
        {
            _entry = entry;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ValuesResponse>), 200), ProducesResponseType(typeof(ResponseWrapper<ErrorResponse>), 404)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            // Use MediatR to call the appropriate handler:  Sample.WebApi.Application.Services.Values.GetAllValuesService 
            ValuesResponse response = await Mediator.Send(new GetAllValuesRequest(), cancellationToken);

            // Add a second entry to the IOC List independent of the Service call
            response.IOCEntries.Add(_entry);

            return WrapResult(response);
        }

        [HttpPut]
        [Route("update/{value}")]
        [ProducesResponseType(typeof(ResponseWrapper<CommandResponse>), 200), ProducesResponseType(typeof(ResponseWrapper<ErrorResponse>), 400)]
        public async Task<IActionResult> update(int value, CancellationToken cancellationToken)
        {
            // Parameter validation
            if (value > 1000)
            {
                return InvalidParameter("Invalid value", "ERRORID#1");
            }

            // Use MediatR to call the appropriate handler:  Sample.WebApi.Application.Services.Values.UpdateValueService 
            CommandResponse response = await Mediator.Send(new UpdateValueRequest() { NewValue = value }, cancellationToken);

            // Add a second entry to the IOC List independent of the Service call
            response.IOCEntries.Add(_entry);

            return WrapResult(response);

        }
    }
}
