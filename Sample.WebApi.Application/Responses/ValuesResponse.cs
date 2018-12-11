using System.Collections.Generic;

namespace Sample.WebApi.Application.Responses
{
    public class ValuesResponse : Response
    {
        public IEnumerable<int> Items { get; set; }
    }
}
