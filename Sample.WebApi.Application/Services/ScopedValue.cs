using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.WebApi.Application.Services
{
    public class ScopedValue
    {
        public ScopedValue()
        {
            Value = Guid.NewGuid();
        }

        public Guid Value { get; set; } 
    }
}
