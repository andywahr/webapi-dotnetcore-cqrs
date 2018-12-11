using System;

namespace Sample.WebApi.ServiceHost.Infrastructure
{
    public class CallContext
    {
        public CallContext()
        {
            TransactionId = Guid.NewGuid();
        }

        public Guid TransactionId { get; set; }
    }
}
