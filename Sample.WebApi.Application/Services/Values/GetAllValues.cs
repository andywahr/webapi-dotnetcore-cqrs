using MediatR;
using Sample.WebApi.Application.Requests.Values;
using Sample.WebApi.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WebApi.Application.Services.Values
{
    public class GetAllValues : IRequestHandler<GetAllValuesRequest, ValuesResponse>
    {
        public async Task<ValuesResponse> Handle(GetAllValuesRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ValuesResponse() { Successfull = true, Items = new int[] { 1, 2 } });
        }
    }
}
