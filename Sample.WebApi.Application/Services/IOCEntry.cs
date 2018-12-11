using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.WebApi.Application.Services
{
    public class IOCEntry
    {
        public IOCEntry(TransiantValue transiant, ScopedValue scoped, SingletonValue singleton)
        {
            Transient = transiant;
            Scoped = scoped;
            Singleton = singleton;
        }

        public TransiantValue Transient { get; set; }
        public ScopedValue Scoped { get; set; }
        public SingletonValue Singleton { get; set; }
    }
}
