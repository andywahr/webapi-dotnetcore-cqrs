using MediatR;
using Sample.WebApi.Application.Requests.Values;
using Sample.WebApi.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WebApi.Application.Services.Values
{
    public class UpdateValue : IRequestHandler<UpdateValueRequest, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UpdateValueRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new CommandResponse() { Successfull = true, CommandType = "UpdateValue" });
        }
    }
}
