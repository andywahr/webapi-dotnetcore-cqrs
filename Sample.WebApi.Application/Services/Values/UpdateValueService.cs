using MediatR;
using Sample.WebApi.Application.Requests.Values;
using Sample.WebApi.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WebApi.Application.Services.Values
{
    public class UpdateValueService : IRequestHandler<UpdateValueRequest, CommandResponse>
    {
        private readonly IOCEntry _entry;
        public UpdateValueService(IOCEntry entry)
        {
            _entry = entry;
        }

        public async Task<CommandResponse> Handle(UpdateValueRequest request, CancellationToken cancellationToken)
        {
            CommandResponse retVal = new CommandResponse() { Successfull = true, CommandType = "UpdateValue" };
            retVal.IOCEntries.Add(_entry);
            return await Task.FromResult(retVal);
        }
    }
}
