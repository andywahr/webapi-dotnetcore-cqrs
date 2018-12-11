using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.WebApi.Application.Services
{
    public class TransiantValue
    {
        public TransiantValue()
        {
            Value = Guid.NewGuid();
        }

        public Guid Value { get; set; }
    }
}
