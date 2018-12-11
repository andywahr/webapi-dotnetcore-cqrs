using MediatR;
using Sample.WebApi.Application.Responses;

namespace Sample.WebApi.Application.Requests.Values
{
    public class GetAllValuesRequest : IRequest<ValuesResponse>
    {
    }
}
