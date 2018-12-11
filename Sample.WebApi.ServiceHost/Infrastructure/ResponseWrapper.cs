using System;
using System.Net;

namespace Sample.WebApi.ServiceHost.Infrastructure
{
    public class ResponseWrapper
    {
        public bool IsSuccess { get; set; }
        public Guid TransactionId { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class ResponseWrapper<T> : ResponseWrapper
    {
        public T Result { get; set; }
    }
}
