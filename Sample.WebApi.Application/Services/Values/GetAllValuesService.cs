using MediatR;
using Sample.WebApi.Application.Requests.Values;
using Sample.WebApi.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WebApi.Application.Services.Values
{
    public class GetAllValuesService : IRequestHandler<GetAllValuesRequest, ValuesResponse>
    {
        private readonly IOCEntry _entry;
        public GetAllValuesService(IOCEntry entry)
        {
            _entry = entry;
        }

        public async Task<ValuesResponse> Handle(GetAllValuesRequest request, CancellationToken cancellationToken)
        {
            ValuesResponse retVal = new ValuesResponse() { Successfull = true, Items = new int[] { 1, 2 } };
            retVal.IOCEntries.Add(_entry);

            return await Task.FromResult(retVal);
        }
    }
}
