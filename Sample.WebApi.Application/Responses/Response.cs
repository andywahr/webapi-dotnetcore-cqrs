using Sample.WebApi.Application.Services;
using System.Collections.Generic;

namespace Sample.WebApi.Application.Responses
{
    public abstract class Response
    {
        public Response()
        {
            IOCEntries = new List<IOCEntry>();
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool Successfull { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string ErrorId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string Message { get; set; }
        public List<IOCEntry> IOCEntries { get; set; }
    }
}
