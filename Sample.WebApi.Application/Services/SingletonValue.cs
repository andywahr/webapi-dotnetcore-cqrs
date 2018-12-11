using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.WebApi.Application.Services
{
    public class SingletonValue
    {
        public SingletonValue()
        {
            Value = Guid.NewGuid();
        }

        public Guid Value { get; set; }
    }
}
