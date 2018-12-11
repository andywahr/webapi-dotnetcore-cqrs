using MediatR;
using Sample.WebApi.Application.Responses;

namespace Sample.WebApi.Application.Requests.Values
{
    public class UpdateValueRequest : IRequest<CommandResponse>
    {
        public int NewValue { get; set; }
    }
}
